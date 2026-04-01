using NuggetMod.Interface.Events;
using NuggetMod.Interface.Events.NativeCaller;

namespace NuggetMod.Helper;

/// <summary>
/// 安全的事件注册管理器，确保所有委托在传递给原生引擎之前被正确保持引用。
/// 这是一个高级API，用于替代直接操作MetaMod.RegisterEvents。
/// </summary>
/// <remarks>
/// 此类解决的问题：
/// 1. 委托被GC回收后原生引擎持有垂悬指针
/// 2. 事件重复注册导致的内存泄漏
/// 3. 事件注销时的竞态条件
/// 
/// 使用示例：
/// <code>
/// var builder = new EventRegistrationBuilder()
///     .WithEntityApi(new MyDLLEvents())
///     .WithEngineFunctions(new MyEngineEvents());
/// SafeEventRegistration.Register(builder);
/// </code>
/// </remarks>
public static class SafeEventRegistration
{
    private const string PREFIX_ENTITY_API = "MetaMod_EntityApi";
    private const string PREFIX_ENTITY_API_POST = "MetaMod_EntityApiPost";
    private const string PREFIX_ENTITY_API2 = "MetaMod_EntityApi2";
    private const string PREFIX_ENTITY_API2_POST = "MetaMod_EntityApi2Post";
    private const string PREFIX_NEW_DLL = "MetaMod_NewDll";
    private const string PREFIX_NEW_DLL_POST = "MetaMod_NewDllPost";
    private const string PREFIX_ENGINE = "MetaMod_Engine";
    private const string PREFIX_ENGINE_POST = "MetaMod_EnginePost";
    private const string PREFIX_BLENDING = "MetaMod_Blending";
    private const string PREFIX_BLENDING_POST = "MetaMod_BlendingPost";

    private static readonly HashSet<string> s_registeredPrefixes = new();
    private static readonly Lock s_lock = new();

    /// <summary>
    /// 使用构建器模式注册事件。
    /// </summary>
    /// <param name="builder">事件注册构建器</param>
    /// <exception cref="ArgumentNullException">当builder为null时</exception>
    /// <exception cref="InvalidOperationException">当相同类型的事件已注册时</exception>
    public static void Register(EventRegistrationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        lock (s_lock)
        {
            // 检查是否有重复注册
            var prefixesToCheck = GetPrefixesFromBuilder(builder);
            foreach (var prefix in prefixesToCheck)
            {
                if (s_registeredPrefixes.Contains(prefix))
                {
                    throw new InvalidOperationException(
                        $"Events with prefix '{prefix}' are already registered. " +
                        $"Use Unregister first or check IsRegistered.");
                }
            }

            // 注册所有委托到生命周期管理器
            RegisterDelegates(builder);

            // 注册到MetaMod
            MetaMod.RegisterEvents(
                entityApi: builder.EntityApi,
                entityApiPost: builder.EntityApiPost,
                entityApi2: builder.EntityApi2,
                entityApi2Post: builder.EntityApi2Post,
                newDllFunctions: builder.NewDllFunctions,
                newDllFunctionsPost: builder.NewDllFunctionsPost,
                engineFunctions: builder.EngineFunctions,
                engineFunctionsPost: builder.EngineFunctionsPost,
                blendingInterface: builder.BlendingInterface,
                blendingInterfacePost: builder.BlendingInterfacePost
            );

            // 标记已注册
            foreach (var prefix in prefixesToCheck)
            {
                s_registeredPrefixes.Add(prefix);
            }
        }
    }

    /// <summary>
    /// 注销所有已注册的事件并允许委托被GC回收。
    /// </summary>
    /// <remarks>
    /// 警告：此方法仅在插件完全卸载时调用！
    /// 调用后所有事件处理将失效。
    /// </remarks>
    public static void UnregisterAll()
    {
        lock (s_lock)
        {
            // 清理所有相关委托
            foreach (var prefix in s_registeredPrefixes)
            {
                var keysToRemove = DelegateLifetimeManager.GetRegisteredKeys()
                    .Where(k => k.StartsWith(prefix + "_", StringComparison.Ordinal))
                    .ToList();

                foreach (var key in keysToRemove)
                {
                    DelegateLifetimeManager.Unregister(key);
                }
            }

            s_registeredPrefixes.Clear();
        }
    }

    /// <summary>
    /// 检查指定类型的事件是否已注册。
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <returns>是否已注册</returns>
    public static bool IsRegistered(EventRegistrationType eventType)
    {
        string prefix = GetPrefixForEventType(eventType);
        lock (s_lock)
        {
            return s_registeredPrefixes.Contains(prefix);
        }
    }

    private static void RegisterDelegates(EventRegistrationBuilder builder)
    {
        // 这里我们注册NativeCaller中使用的内部委托
        // 这些委托在MetaMod.LinkNative*方法中被转换为函数指针

        if (builder.EntityApi != null)
        {
            RegisterEntityApiDelegates(PREFIX_ENTITY_API);
        }
        if (builder.EntityApiPost != null)
        {
            RegisterEntityApiDelegates(PREFIX_ENTITY_API_POST);
        }
        if (builder.EntityApi2 != null)
        {
            RegisterEntityApi2Delegates(PREFIX_ENTITY_API2);
        }
        if (builder.EntityApi2Post != null)
        {
            RegisterEntityApi2Delegates(PREFIX_ENTITY_API2_POST);
        }
        if (builder.NewDllFunctions != null)
        {
            RegisterNewDllDelegates(PREFIX_NEW_DLL);
        }
        if (builder.NewDllFunctionsPost != null)
        {
            RegisterNewDllDelegates(PREFIX_NEW_DLL_POST);
        }
        if (builder.EngineFunctions != null)
        {
            RegisterEngineDelegates(PREFIX_ENGINE);
        }
        if (builder.EngineFunctionsPost != null)
        {
            RegisterEngineDelegates(PREFIX_ENGINE_POST);
        }
        if (builder.BlendingInterface != null)
        {
            RegisterBlendingDelegates(PREFIX_BLENDING);
        }
        if (builder.BlendingInterfacePost != null)
        {
            RegisterBlendingDelegates(PREFIX_BLENDING_POST);
        }
    }

    private static void RegisterEntityApiDelegates(string prefix)
    {
        // 这些委托在NativeCaller类中定义，我们需要确保它们被保持引用
        // 由于NativeCaller使用静态字段，它们本身不会被GC回收
        // 但为了统一管理和文档目的，我们在这里进行"注册"（实际上只是记录）
        DelegateLifetimeManager.TryRegister($"{prefix}_Wrapper", MetaMod.GetEntityApiWrapper);
    }

    private static void RegisterEntityApi2Delegates(string prefix)
    {
        DelegateLifetimeManager.TryRegister($"{prefix}_Wrapper", MetaMod.GetEntityApi2Wrapper);
    }

    private static void RegisterNewDllDelegates(string prefix)
    {
        DelegateLifetimeManager.TryRegister($"{prefix}_Wrapper", MetaMod.GetNewDllFunctionsWrapper);
    }

    private static void RegisterEngineDelegates(string prefix)
    {
        DelegateLifetimeManager.TryRegister($"{prefix}_Wrapper", MetaMod.GetEngineFunctions);
    }

    private static void RegisterBlendingDelegates(string prefix)
    {
        DelegateLifetimeManager.TryRegister($"{prefix}_Wrapper", MetaMod.GetBlendingInterfaceDelegate);
    }

    private static IEnumerable<string> GetPrefixesFromBuilder(EventRegistrationBuilder builder)
    {
        var prefixes = new List<string>();
        if (builder.EntityApi != null) prefixes.Add(PREFIX_ENTITY_API);
        if (builder.EntityApiPost != null) prefixes.Add(PREFIX_ENTITY_API_POST);
        if (builder.EntityApi2 != null) prefixes.Add(PREFIX_ENTITY_API2);
        if (builder.EntityApi2Post != null) prefixes.Add(PREFIX_ENTITY_API2_POST);
        if (builder.NewDllFunctions != null) prefixes.Add(PREFIX_NEW_DLL);
        if (builder.NewDllFunctionsPost != null) prefixes.Add(PREFIX_NEW_DLL_POST);
        if (builder.EngineFunctions != null) prefixes.Add(PREFIX_ENGINE);
        if (builder.EngineFunctionsPost != null) prefixes.Add(PREFIX_ENGINE_POST);
        if (builder.BlendingInterface != null) prefixes.Add(PREFIX_BLENDING);
        if (builder.BlendingInterfacePost != null) prefixes.Add(PREFIX_BLENDING_POST);
        return prefixes;
    }

    private static string GetPrefixForEventType(EventRegistrationType eventType)
    {
        return eventType switch
        {
            EventRegistrationType.EntityApi => PREFIX_ENTITY_API,
            EventRegistrationType.EntityApiPost => PREFIX_ENTITY_API_POST,
            EventRegistrationType.EntityApi2 => PREFIX_ENTITY_API2,
            EventRegistrationType.EntityApi2Post => PREFIX_ENTITY_API2_POST,
            EventRegistrationType.NewDllFunctions => PREFIX_NEW_DLL,
            EventRegistrationType.NewDllFunctionsPost => PREFIX_NEW_DLL_POST,
            EventRegistrationType.EngineFunctions => PREFIX_ENGINE,
            EventRegistrationType.EngineFunctionsPost => PREFIX_ENGINE_POST,
            EventRegistrationType.BlendingInterface => PREFIX_BLENDING,
            EventRegistrationType.BlendingInterfacePost => PREFIX_BLENDING_POST,
            _ => throw new ArgumentOutOfRangeException(nameof(eventType))
        };
    }
}

/// <summary>
/// 事件注册类型枚举。
/// </summary>
public enum EventRegistrationType
{
    EntityApi,
    EntityApiPost,
    EntityApi2,
    EntityApi2Post,
    NewDllFunctions,
    NewDllFunctionsPost,
    EngineFunctions,
    EngineFunctionsPost,
    BlendingInterface,
    BlendingInterfacePost
}

/// <summary>
/// 事件注册构建器，用于fluent API风格的事件注册。
/// </summary>
public sealed class EventRegistrationBuilder
{
    internal DLLEvents? EntityApi { get; private set; }
    internal DLLEvents? EntityApiPost { get; private set; }
    internal DLLEvents? EntityApi2 { get; private set; }
    internal DLLEvents? EntityApi2Post { get; private set; }
    internal NewDLLEvents? NewDllFunctions { get; private set; }
    internal NewDLLEvents? NewDllFunctionsPost { get; private set; }
    internal EngineEvents? EngineFunctions { get; private set; }
    internal EngineEvents? EngineFunctionsPost { get; private set; }
    internal BlendingInterfaceEvent? BlendingInterface { get; private set; }
    internal BlendingInterfaceEvent? BlendingInterfacePost { get; private set; }

    /// <summary>
    /// 设置Entity API事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEntityApi(DLLEvents events)
    {
        EntityApi = events;
        return this;
    }

    /// <summary>
    /// 设置Entity API Post事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEntityApiPost(DLLEvents events)
    {
        EntityApiPost = events;
        return this;
    }

    /// <summary>
    /// 设置Entity API2事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEntityApi2(DLLEvents events)
    {
        EntityApi2 = events;
        return this;
    }

    /// <summary>
    /// 设置Entity API2 Post事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEntityApi2Post(DLLEvents events)
    {
        EntityApi2Post = events;
        return this;
    }

    /// <summary>
    /// 设置New DLL Functions事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithNewDllFunctions(NewDLLEvents events)
    {
        NewDllFunctions = events;
        return this;
    }

    /// <summary>
    /// 设置New DLL Functions Post事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithNewDllFunctionsPost(NewDLLEvents events)
    {
        NewDllFunctionsPost = events;
        return this;
    }

    /// <summary>
    /// 设置Engine Functions事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEngineFunctions(EngineEvents events)
    {
        EngineFunctions = events;
        return this;
    }

    /// <summary>
    /// 设置Engine Functions Post事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithEngineFunctionsPost(EngineEvents events)
    {
        EngineFunctionsPost = events;
        return this;
    }

    /// <summary>
    /// 设置Blending Interface事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithBlendingInterface(BlendingInterfaceEvent events)
    {
        BlendingInterface = events;
        return this;
    }

    /// <summary>
    /// 设置Blending Interface Post事件处理器。
    /// </summary>
    public EventRegistrationBuilder WithBlendingInterfacePost(BlendingInterfaceEvent events)
    {
        BlendingInterfacePost = events;
        return this;
    }
}
