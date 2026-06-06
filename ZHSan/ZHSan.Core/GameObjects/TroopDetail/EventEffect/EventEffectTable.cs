using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameObjects.TroopDetail.EventEffect;

[DataContract]
public class EventEffectTable
{
    [DataMember]
    public Dictionary<int, EventEffect> EventEffects { get; set; } = new();

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="eventEffect"></param>
    /// <returns></returns>
    public bool Add(EventEffect eventEffect)
    {
        return EventEffects.TryAdd(eventEffect.ID, eventEffect);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Remove(int id)
    {
        return EventEffects.Remove(id);
    }

    /// <summary>
    /// 查找
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EventEffect Get(int id)
    {
        EventEffects.TryGetValue(id, out var eventEffect);

        return eventEffect;
    }

    public int Count => EventEffects.Count;

    public void Clear() => EventEffects.Clear();

    public IEnumerable<EventEffect> Values => EventEffects.Values;

    public bool HasEventEffect(int id) => EventEffects.ContainsKey(id);
}