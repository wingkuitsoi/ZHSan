
using System.Runtime.Serialization;

namespace GameObjects.PersonDetail;

/// <summary>
/// 状态效果配置
/// </summary>
[DataContract]
public class StatusEffectConfig : GameObject
{
    /// <summary>
    /// 延续天数
    /// </summary>
    [DataMember]
    public int Duration { get; set; }

    /// <summary>
    /// 状态类型
    /// </summary>
    [DataMember]
    public int StatusType { get; set; }

    /// <summary>
    /// 触发条件
    /// </summary>
    [DataMember]
    public string TriggerConditions { get; set; }

    /// <summary>
    /// 影响
    /// </summary>
    [DataMember]
    public string Influences { get; set; }
}