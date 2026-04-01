using System.Runtime.InteropServices;

namespace NuggetMod.Helper;

/// <summary>
/// 安全的委托包装器，确保委托在原生引擎使用期间不会被GC回收。
/// 实现IDisposable接口以在适当时机释放委托。
/// </summary>
/// <typeparam name="T">委托类型</typeparam>
/// <remarks>
/// 使用场景：
/// 1. 短期回调（如单次查询回调）
/// 2. 需要显式生命周期的回调
/// 3. 动态注册/注销的命令
/// 
/// 注意：对于长期回调（如服务器命令），请直接使用DelegateLifetimeManager.Register
/// </remarks>
public sealed class SafeDelegateHandle<T> : IDisposable where T : Delegate
{
    private readonly string _key;
    private T? _delegate;
    private nint _functionPointer;
    private bool _disposed;
    private readonly bool _unregisterOnDispose;

    /// <summary>
    /// 创建一个新的安全委托句柄。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">委托实例</param>
    /// <param name="unregisterOnDispose">是否在Dispose时注销委托</param>
    public SafeDelegateHandle(string key, T @delegate, bool unregisterOnDispose = true)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _delegate = @delegate ?? throw new ArgumentNullException(nameof(@delegate));
        _unregisterOnDispose = unregisterOnDispose;

        // 注册到生命周期管理器
        DelegateLifetimeManager.Register(key, @delegate);

        // 获取函数指针
        _functionPointer = Marshal.GetFunctionPointerForDelegate(@delegate);
    }

    /// <summary>
    /// 获取函数指针，用于传递给原生引擎。
    /// </summary>
    /// <returns>函数指针</returns>
    /// <exception cref="ObjectDisposedException">当句柄已被释放时</exception>
    public nint GetFunctionPointer()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        return _functionPointer;
    }

    /// <summary>
    /// 获取原始委托实例。
    /// </summary>
    /// <returns>委托实例</returns>
    /// <exception cref="ObjectDisposedException">当句柄已被释放时</exception>
    public T GetDelegate()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        return _delegate!;
    }

    /// <summary>
    /// 获取注册时使用的key。
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// 获取是否已在Dispose时自动注销。
    /// </summary>
    public bool UnregisterOnDispose => _unregisterOnDispose;

    /// <summary>
    /// 释放资源。
    /// </summary>
    public void Dispose()
    {
        if (_disposed) return;

        if (_unregisterOnDispose)
        {
            DelegateLifetimeManager.Unregister(_key);
        }

        _functionPointer = nint.Zero;
        _delegate = null;
        _disposed = true;
    }

    /// <summary>
    /// 手动注销委托（即使UnregisterOnDispose为false）。
    /// </summary>
    /// <returns>是否成功注销</returns>
    /// <exception cref="ObjectDisposedException">当句柄已被释放时</exception>
    public bool Unregister()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        return DelegateLifetimeManager.Unregister(_key);
    }

    /// <summary>
    /// 创建新的安全委托句柄的便捷方法。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">委托实例</param>
    /// <returns>安全委托句柄</returns>
    public static SafeDelegateHandle<T> Create(string key, T @delegate)
    {
        return new SafeDelegateHandle<T>(key, @delegate);
    }

    /// <summary>
    /// 隐式转换为函数指针。
    /// </summary>
    public static implicit operator nint(SafeDelegateHandle<T> handle)
    {
        return handle.GetFunctionPointer();
    }
}

/// <summary>
/// SafeDelegateHandle的非泛型便捷工厂类。
/// </summary>
public static class SafeDelegateHandle
{
    /// <summary>
    /// 创建一个新的安全委托句柄。
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <param name="delegate">委托实例</param>
    /// <returns>安全委托句柄</returns>
    public static SafeDelegateHandle<T> Create<T>(string key, T @delegate) where T : Delegate
    {
        return new SafeDelegateHandle<T>(key, @delegate);
    }
}
