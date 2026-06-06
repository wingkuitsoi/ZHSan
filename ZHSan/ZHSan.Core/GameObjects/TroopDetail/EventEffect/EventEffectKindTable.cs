using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameObjects.TroopDetail.EventEffect;

[DataContract]
public class EventEffectKindTable
{
    [DataMember]
    public Dictionary<int, EventEffectKind> EventEffectKinds { get; set; } = new();

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="eventEffectKind"></param>
    /// <returns></returns>
    public bool Add(EventEffectKind eventEffectKind)
    {
        return EventEffectKinds.TryAdd(eventEffectKind.ID, eventEffectKind);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Remove(int id)
    {
        return EventEffectKinds.Remove(id);
    }

    /// <summary>
    /// 查找
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EventEffectKind Get(int id)
    {
        EventEffectKinds.TryGetValue(id, out var kind);

        return kind;
    }

    public int Count => EventEffectKinds.Count;

    public void Clear() => EventEffectKinds.Clear();

    public IEnumerable<EventEffectKind> Values => EventEffectKinds.Values;

    public bool HasEventEffectKind(int id) => EventEffectKinds.ContainsKey(id);
}