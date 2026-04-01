using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace NuggetMod.Helper;

/// <summary>
/// 安全地管理委托生命周期，防止GC回收导致的垂悬指针问题。
/// 这是一个全局委托注册表，确保传递给原生引擎的委托永远不会被GC回收。
/// </summary>
/// <remarks>
/// 设计原理：
/// 1. 所有传递给原生引擎的委托必须在此注册
/// 2. 使用强引用保持委托存活
/// 3. 提供Unregister方法在适当时机释放委托
/// 4. 插件卸载时自动清理所有注册的委托
/// </remarks>
public static class DelegateLifetimeManager
{
    // 使用并发字典确保线程安全
    private static readonly ConcurrentDictionary<string, Delegate> s_registeredDelegates = new();
    private static readonly ConcurrentDictionary<nint, string> s_pointerToKeyMap = new();
    private static readonly Lock s_lock = new();

    /// <summary>
    /// 注册一个委托，确保其不会被GC回收。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符（建议使用 "组件名_委托用途" 格式）</param>
    /// <param name="delegate">要注册的委托实例</param>
    /// <returns>注册的委托实例（用于链式调用）</returns>
    /// <exception cref="ArgumentNullException">当key或delegate为null时</exception>
    /// <exception cref="InvalidOperationException">当key已被使用时</exception>
    public static T Register<T>(string key, T @delegate) where T : Delegate
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        ArgumentNullException.ThrowIfNull(@delegate, nameof(@delegate));

        if (!s_registeredDelegates.TryAdd(key, @delegate))
        {
            throw new InvalidOperationException(
                $"Delegate with key '{key}' is already registered. " +
                $"Use Unregister first if you want to replace it, or use TryRegister.");
        }

        // 获取函数指针并建立映射
        nint ptr = Marshal.GetFunctionPointerForDelegate(@delegate);
        s_pointerToKeyMap[ptr] = key;

        return @delegate;
    }

    /// <summary>
    /// 尝试注册一个委托。如果key已存在，返回false而不是抛出异常。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">要注册的委托实例</param>
    /// <returns>是否成功注册</returns>
    public static bool TryRegister<T>(string key, T @delegate) where T : Delegate
    {
        if (key == null || @delegate == null)
            return false;

        if (!s_registeredDelegates.TryAdd(key, @delegate))
            return false;

        nint ptr = Marshal.GetFunctionPointerForDelegate(@delegate);
        s_pointerToKeyMap[ptr] = key;
        return true;
    }

    /// <summary>
    /// 注册或替换一个委托。如果key已存在，先注销旧委托。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">新的委托实例</param>
    /// <returns>注册的委托实例</returns>
    public static T RegisterOrReplace<T>(string key, T @delegate) where T : Delegate
    {
        Unregister(key);
        return Register(key, @delegate);
    }

    /// <summary>
    /// 获取已注册的委托。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <returns>委托实例，如果未找到则返回null</returns>
    public static T? Get<T>(string key) where T : Delegate
    {
        if (s_registeredDelegates.TryGetValue(key, out Delegate? del))
        {
            return del as T;
        }
        return null;
    }

    /// <summary>
    /// 检查是否已注册指定key的委托。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <returns>是否已注册</returns>
    public static bool IsRegistered(string key)
    {
        return s_registeredDelegates.ContainsKey(key);
    }

    /// <summary>
    /// 注销一个委托，允许其被GC回收。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <returns>是否成功注销</returns>
    /// <remarks>
    /// 警告：只有在确定原生引擎不再调用此委托后才能注销！
    /// 通常在服务器关闭或命令被移除时调用。
    /// </remarks>
    public static bool Unregister(string key)
    {
        if (s_registeredDelegates.TryRemove(key, out Delegate? del))
        {
            // 清理指针映射
            nint ptr = Marshal.GetFunctionPointerForDelegate(del);
            s_pointerToKeyMap.TryRemove(ptr, out _);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 通过函数指针查找并注销委托。
    /// </summary>
    /// <param name="functionPointer">函数指针</param>
    /// <returns>是否成功注销</returns>
    public static bool UnregisterByPointer(nint functionPointer)
    {
        if (s_pointerToKeyMap.TryRemove(functionPointer, out string? key))
        {
            s_registeredDelegates.TryRemove(key, out _);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获取所有已注册的委托key。
    /// </summary>
    /// <returns>Key集合</returns>
    public static IEnumerable<string> GetRegisteredKeys()
    {
        return s_registeredDelegates.Keys.ToList();
    }

    /// <summary>
    /// 获取已注册委托的数量。
    /// </summary>
    /// <returns>委托数量</returns>
    public static int Count => s_registeredDelegates.Count;

    /// <summary>
    /// 注销所有委托。
    /// </summary>
    /// <remarks>
    /// 警告：此方法仅在插件完全卸载时调用！
    /// 调用后所有原生回调将变为无效。
    /// </remarks>
    public static void UnregisterAll()
    {
        s_registeredDelegates.Clear();
        s_pointerToKeyMap.Clear();
    }

    /// <summary>
    /// 创建带有作用域的注册，using语句结束时自动注销。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">委托实例</param>
    /// <returns>可释放的注册句柄</returns>
    /// <remarks>
    /// 注意：只有在确定原生引擎不再需要回调后才能使用using模式！
    /// 大多数情况下，委托应该保持注册直到服务器关闭。
    /// </remarks>
    public static IDisposable RegisterScoped<T>(string key, T @delegate) where T : Delegate
    {
        Register(key, @delegate);
        return new DelegateRegistrationHandle(key);
    }

    private sealed class DelegateRegistrationHandle : IDisposable
    {
        private readonly string _key;
        private bool _disposed;

        public DelegateRegistrationHandle(string key)
        {
            _key = key;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Unregister(_key);
                _disposed = true;
            }
        }
    }
}

/// <summary>
/// 委托注册异常。
/// </summary>
public class DelegateRegistrationException : Exception
{
    public DelegateRegistrationException(string message) : base(message) { }
    public DelegateRegistrationException(string message, Exception inner) : base(message, inner) { }
}
