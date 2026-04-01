using System.Collections.Concurrent;

namespace NuggetMod.Helper;

/// <summary>
/// 管理原生包装器对象的生命周期，防止GC回收导致垂悬指针。
/// 适用于需要长期保持存活的对象（如CVars、注册的资源等）。
/// </summary>
/// <remarks>
/// 使用场景：
/// 1. CVar实例 - 注册到引擎后必须保持存活
/// 2. 长期存在的回调委托
/// 3. 共享的原生内存缓冲区
///
/// 不使用场景：
/// 1. 临时查询返回的包装器（短暂使用即可丢弃）
/// 2. 引擎拥有内存的包装器（如通过FindEntity获取的Edict）
///
/// 使用示例：
/// <code>
/// var cvar = new CVar("my_cvar", "default_value");
/// engineFuncs.CVarRegister(cvar);
/// NativeObjectLifetimeManager.KeepAlive(cvar.Name, cvar);
/// </code>
/// </remarks>
public static class NativeObjectLifetimeManager
{
    // 使用并发字典确保线程安全
    private static readonly ConcurrentDictionary<string, object> s_trackedObjects = new();

    /// <summary>
    /// 保持对象存活，防止其被GC回收。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="obj">要保持存活的对象</param>
    /// <exception cref="ArgumentNullException">当key或obj为null时</exception>
    /// <exception cref="InvalidOperationException">当相同key已存在时</exception>
    public static void KeepAlive(string key, object obj)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));

        if (!s_trackedObjects.TryAdd(key, obj))
        {
            throw new InvalidOperationException(
                $"Object with key '{key}' is already being tracked. " +
                $"Use Release first, or use TryKeepAlive/KeepAliveOrReplace.");
        }
    }

    /// <summary>
    /// 尝试保持对象存活。如果key已存在，返回false。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="obj">要保持存活的对象</param>
    /// <returns>是否成功添加</returns>
    public static bool TryKeepAlive(string key, object obj)
    {
        if (key == null || obj == null)
            return false;

        return s_trackedObjects.TryAdd(key, obj);
    }

    /// <summary>
    /// 保持对象存活，或替换已存在的对象。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="obj">要保持存活的对象</param>
    public static void KeepAliveOrReplace(string key, object obj)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));

        s_trackedObjects[key] = obj;
    }

    /// <summary>
    /// 获取已跟踪的对象。
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <returns>对象实例，如果未找到则返回null</returns>
    public static T? Get<T>(string key) where T : class
    {
        if (s_trackedObjects.TryGetValue(key, out object? obj))
        {
            return obj as T;
        }
        return null;
    }

    /// <summary>
    /// 检查对象是否被跟踪。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <returns>是否正在跟踪</returns>
    public static bool IsTracked(string key)
    {
        return s_trackedObjects.ContainsKey(key);
    }

    /// <summary>
    /// 释放对象，允许其被GC回收。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <returns>是否成功释放（如果key不存在返回false）</returns>
    /// <remarks>
    /// 警告：只有在确定原生引擎不再引用此对象后才能调用！
    /// </remarks>
    public static bool Release(string key)
    {
        return s_trackedObjects.TryRemove(key, out _);
    }

    /// <summary>
    /// 释放对象并获取其实例。
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="key">唯一标识符</param>
    /// <param name="obj">输出对象实例</param>
    /// <returns>是否成功释放</returns>
    public static bool TryRelease<T>(string key, out T? obj) where T : class
    {
        if (s_trackedObjects.TryRemove(key, out object? value))
        {
            obj = value as T;
            return true;
        }
        obj = null;
        return false;
    }

    /// <summary>
    /// 对所有已跟踪的对象执行操作。
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="action">要执行的操作</param>
    public static void ForEach<T>(Action<string, T> action) where T : class
    {
        foreach (var kvp in s_trackedObjects)
        {
            if (kvp.Value is T typedObj)
            {
                action(kvp.Key, typedObj);
            }
        }
    }

    /// <summary>
    /// 获取所有已跟踪的指定类型的对象。
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象列表</returns>
    public static IEnumerable<KeyValuePair<string, T>> GetAllOfType<T>() where T : class
    {
        return s_trackedObjects
            .Where(kvp => kvp.Value is T)
            .Select(kvp => new KeyValuePair<string, T>(kvp.Key, (T)kvp.Value));
    }

    /// <summary>
    /// 获取已跟踪对象的数量。
    /// </summary>
    public static int Count => s_trackedObjects.Count;

    /// <summary>
    /// 获取所有已跟踪对象的key。
    /// </summary>
    public static IEnumerable<string> Keys => s_trackedObjects.Keys.ToList();

    /// <summary>
    /// 根据key前缀释放对象。
    /// </summary>
    /// <param name="prefix">Key前缀</param>
    /// <returns>释放的对象数量</returns>
    /// <remarks>
    /// 警告：确保这些对象不再被原生引擎引用！
    /// </remarks>
    public static int ReleaseByPrefix(string prefix)
    {
        var keysToRemove = s_trackedObjects.Keys.Where(k => k.StartsWith(prefix, StringComparison.Ordinal)).ToList();
        int count = 0;
        foreach (var key in keysToRemove)
        {
            if (s_trackedObjects.TryRemove(key, out _))
                count++;
        }
        return count;
    }

    /// <summary>
    /// 释放所有对象。
    /// </summary>
    /// <remarks>
    /// 警告：此方法仅在插件完全卸载时调用！
    /// 调用后所有跟踪的对象都可能被GC回收。
    /// </remarks>
    public static void ReleaseAll()
    {
        s_trackedObjects.Clear();
    }

    /// <summary>
    /// 创建作用域跟踪，在using语句结束时自动释放。
    /// </summary>
    /// <param name="key">唯一标识符</param>
    /// <param name="obj">要保持存活的对象</param>
    /// <returns>可释放的跟踪句柄</returns>
    /// <remarks>
    /// 注意：只有在确定原生引擎不再需要对象后才能使用using模式！
    /// </remarks>
    public static IDisposable TrackScoped(string key, object obj)
    {
        KeepAlive(key, obj);
        return new TrackedObjectHandle(key);
    }

    private sealed class TrackedObjectHandle : IDisposable
    {
        private readonly string _key;
        private bool _disposed;

        public TrackedObjectHandle(string key)
        {
            _key = key;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Release(_key);
                _disposed = true;
            }
        }
    }
}

/// <summary>
/// 原生对象生命周期管理器的扩展方法。
/// </summary>
public static class NativeObjectLifetimeManagerExtensions
{
    /// <summary>
    /// 将此对象注册到生命周期管理器以保持存活。
    /// </summary>
    /// <param name="obj">对象实例</param>
    /// <param name="key">唯一标识符</param>
    public static void KeepAlive(this object obj, string key)
    {
        NativeObjectLifetimeManager.KeepAlive(key, obj);
    }

    /// <summary>
    /// 尝试将此对象注册到生命周期管理器以保持存活。
    /// </summary>
    /// <param name="obj">对象实例</param>
    /// <param name="key">唯一标识符</param>
    /// <returns>是否成功注册</returns>
    public static bool TryKeepAlive(this object obj, string key)
    {
        return NativeObjectLifetimeManager.TryKeepAlive(key, obj);
    }
}
