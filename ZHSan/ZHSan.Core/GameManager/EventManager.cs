
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EventManager
{
    private static readonly EventManager _instance = new();
    public static EventManager Instance => _instance;

    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    /// <summary>
    /// 订阅
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="handler"></param>
    public void Subscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        if (!_handlers.ContainsKey(type))
            _handlers[type] = new List<Delegate>();

        _handlers[type].Add(handler);
    }

    /// <summary>
    /// 取消订阅
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="handler"></param>
    public void Unsubscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        if (_handlers.TryGetValue(type, out var list))
        {
            list.Remove(handler);
        }
    }

    /// <summary>
    /// 发布（同步）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    public void Publish<T>(T message)
    {
        var type = typeof(T);

        if (!_handlers.TryGetValue(type, out var list)) return;

        foreach (var handler in list)
            handler.DynamicInvoke(message);
    }

    /// <summary>
    /// 发布（异步）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task PublishAsync<T>(T message)
    {
        var type = typeof(T);

        if (!_handlers.TryGetValue(type, out var list)) return;

        var tasks = new List<Task>();
        foreach (var handler in list)
            tasks.Add(Task.Run(() => handler.DynamicInvoke(message)));

        await Task.WhenAll(tasks);
    }
}