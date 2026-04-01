using NuggetMod.Interface;
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
    private static readonly Lock s_lock = new();
    private static readonly HashSet<string> s_registeredPrefixes = new();

    // 事件类型定义：前缀、属性Getter、包装器委托Getter
    private static readonly EventTypeDefinition[] s_eventTypes =
    [
        new(PREFIX_ENTITY_API,       b => b.EntityApi,       () => MetaMod.GetEntityApiWrapper),
        new(PREFIX_ENTITY_API_POST,  b => b.EntityApiPost,   () => MetaMod.GetEntityApiWrapper),
        new(PREFIX_ENTITY_API2,      b => b.EntityApi2,      () => MetaMod.GetEntityApi2Wrapper),
        new(PREFIX_ENTITY_API2_POST, b => b.EntityApi2Post,  () => MetaMod.GetEntityApi2Wrapper),
        new(PREFIX_NEW_DLL,          b => b.NewDllFunctions, () => MetaMod.GetNewDllFunctionsWrapper),
        new(PREFIX_NEW_DLL_POST,     b => b.NewDllFunctionsPost, () => MetaMod.GetNewDllFunctionsWrapper),
        new(PREFIX_ENGINE,           b => b.EngineFunctions, () => MetaMod.GetEngineFunctions),
        new(PREFIX_ENGINE_POST,      b => b.EngineFunctionsPost, () => MetaMod.GetEngineFunctions),
        new(PREFIX_BLENDING,         b => b.BlendingInterface, () => MetaMod.GetBlendingInterfaceDelegate),
        new(PREFIX_BLENDING_POST,    b => b.BlendingInterfacePost, () => MetaMod.GetBlendingInterfaceDelegate),
    ];

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

    /// <summary>
    /// 事件类型定义，包含前缀、属性Getter和包装器委托Getter。
    /// </summary>
    private sealed record EventTypeDefinition(
        string Prefix,
        Func<EventRegistrationBuilder, object?> PropertyGetter,
        Func<Delegate> WrapperGetter
    );

    /// <summary>
    /// 使用构建器模式注册事件。
    /// </summary>
    /// <param name="builder">事件注册构建器</param>
    /// <exception cref="ArgumentNullException">当builder为null时</exception>
    /// <exception cref="InvalidOperationException">当相同类型的事件已注册时</exception>
    public static void Register(EventRegistrationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        var activeTypes = GetActiveEventTypes(builder);

        lock (s_lock)
        {
            // 检查是否有重复注册
            foreach (var typeDef in activeTypes)
            {
                if (s_registeredPrefixes.Contains(typeDef.Prefix))
                {
                    throw new InvalidOperationException(
                        $"Events with prefix '{typeDef.Prefix}' are already registered. " +
                        $"Use Unregister first or check IsRegistered.");
                }
            }

            // 注册所有委托到生命周期管理器（通过Wrapper保持引用）
            foreach (var typeDef in activeTypes)
            {
                DelegateLifetimeManager.TryRegister($"{typeDef.Prefix}_Wrapper", typeDef.WrapperGetter());
            }

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
            foreach (var typeDef in activeTypes)
            {
                s_registeredPrefixes.Add(typeDef.Prefix);
            }
        }
    }

    /// <summary>
    /// 获取构建器中已设置的事件类型定义。
    /// </summary>
    private static List<EventTypeDefinition> GetActiveEventTypes(EventRegistrationBuilder builder)
    {
        var result = new List<EventTypeDefinition>(s_eventTypes.Length);
        foreach (var typeDef in s_eventTypes)
        {
            if (typeDef.PropertyGetter(builder) != null)
            {
                result.Add(typeDef);
            }
        }
        return result;
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
            var keysToRemove = DelegateLifetimeManager.GetRegisteredKeys()
                .Where(k => s_registeredPrefixes.Any(p => k.StartsWith(p + "_", StringComparison.Ordinal)))
                .ToList();

            foreach (var key in keysToRemove)
            {
                DelegateLifetimeManager.Unregister(key);
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
        var prefix = GetPrefixForEventType(eventType);
        lock (s_lock)
        {
            return s_registeredPrefixes.Contains(prefix);
        }
    }

    /// <summary>
    /// 获取所有已注册的事件类型。
    /// </summary>
    /// <returns>已注册的事件类型集合</returns>
    public static IReadOnlyCollection<EventRegistrationType> GetRegisteredTypes()
    {
        lock (s_lock)
        {
            return s_registeredPrefixes
                .Where(p => s_prefixToEventType.TryGetValue(p, out _))
                .Select(p => s_prefixToEventType[p])
                .ToList()
                .AsReadOnly();
        }
    }

    // 前缀到事件类型的映射
    private static readonly Dictionary<string, EventRegistrationType> s_prefixToEventType = new()
    {
        [PREFIX_ENTITY_API] = EventRegistrationType.EntityApi,
        [PREFIX_ENTITY_API_POST] = EventRegistrationType.EntityApiPost,
        [PREFIX_ENTITY_API2] = EventRegistrationType.EntityApi2,
        [PREFIX_ENTITY_API2_POST] = EventRegistrationType.EntityApi2Post,
        [PREFIX_NEW_DLL] = EventRegistrationType.NewDllFunctions,
        [PREFIX_NEW_DLL_POST] = EventRegistrationType.NewDllFunctionsPost,
        [PREFIX_ENGINE] = EventRegistrationType.EngineFunctions,
        [PREFIX_ENGINE_POST] = EventRegistrationType.EngineFunctionsPost,
        [PREFIX_BLENDING] = EventRegistrationType.BlendingInterface,
        [PREFIX_BLENDING_POST] = EventRegistrationType.BlendingInterfacePost,
    };

    /// <summary>
    /// 验证事件注册是否安全（无重复注册风险）。
    /// </summary>
    /// <param name="builder">事件注册构建器</param>
    /// <returns>验证结果，包含是否可以安全注册</returns>
    public static ValidationResult ValidateRegistration(EventRegistrationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        var activeTypes = GetActiveEventTypes(builder);
        var conflicts = new List<string>();

        lock (s_lock)
        {
            foreach (var typeDef in activeTypes)
            {
                if (s_registeredPrefixes.Contains(typeDef.Prefix))
                {
                    conflicts.Add(typeDef.Prefix);
                }
            }
        }

        return new ValidationResult
        {
            CanRegister = conflicts.Count == 0,
            ConflictingTypes = conflicts.AsReadOnly()
        };
    }

    /// <summary>
    /// 尝试注册事件，如果存在冲突则返回false而不抛出异常。
    /// </summary>
    /// <param name="builder">事件注册构建器</param>
    /// <returns>是否成功注册</returns>
    public static bool TryRegister(EventRegistrationBuilder builder)
    {
        try
        {
            Register(builder);
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    /// <summary>
    /// 确保所有事件处理器都被正确保持引用，防止GC回收。
    /// 此方法在Register中自动调用，但也可以手动调用以验证。
    /// </summary>
    /// <param name="builder">事件注册构建器</param>
    /// <returns>已保持引用的委托数量</returns>
    public static int EnsureDelegatesPinned(EventRegistrationBuilder builder)
    {
        var activeTypes = GetActiveEventTypes(builder);

        foreach (var typeDef in activeTypes)
        {
            DelegateLifetimeManager.TryRegister($"{typeDef.Prefix}_Wrapper", typeDef.WrapperGetter());
        }

        return activeTypes.Count;
    }

    // 辅助方法已移除，功能被 GetActiveEventTypes 替代

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
    /// <summary>Entity API 事件</summary>
    EntityApi,
    /// <summary>Entity API Post 事件</summary>
    EntityApiPost,
    /// <summary>Entity API2 事件</summary>
    EntityApi2,
    /// <summary>Entity API2 Post 事件</summary>
    EntityApi2Post,
    /// <summary>New DLL Functions 事件</summary>
    NewDllFunctions,
    /// <summary>New DLL Functions Post 事件</summary>
    NewDllFunctionsPost,
    /// <summary>Engine Functions 事件</summary>
    EngineFunctions,
    /// <summary>Engine Functions Post 事件</summary>
    EngineFunctionsPost,
    /// <summary>Blending Interface 事件</summary>
    BlendingInterface,
    /// <summary>Blending Interface Post 事件</summary>
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

/// <summary>
/// 事件注册验证结果。
/// </summary>
public readonly struct ValidationResult
{
    /// <summary>
    /// 是否可以安全注册。
    /// </summary>
    public required bool CanRegister { get; init; }

    /// <summary>
    /// 冲突的事件类型列表。
    /// </summary>
    public required IReadOnlyCollection<string> ConflictingTypes { get; init; }

    /// <summary>
    /// 是否有冲突。
    /// </summary>
    public bool HasConflicts => ConflictingTypes.Count > 0;
}
