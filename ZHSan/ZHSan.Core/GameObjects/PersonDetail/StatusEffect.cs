
namespace GameObjects.PersonDetail;

/// <summary>
/// 状态效果
/// 管理人物的临时状态
/// </summary>
public class StatusEffect
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; private set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 延续时间
    /// </summary>
    public int Duration { get; private set; }

    /// <summary>
    /// 状态类型
    /// </summary>
    public int StatusType { get; private set; }

    /// <summary>
    /// 触发条件
    /// </summary>
    public string TriggerConditions { get; private set; }

    /// <summary>
    /// 影响
    /// </summary>
    public string Influences { get; private set; }

    public StatusEffect(StatusEffectConfig config)
    {
        ID = config.ID;
        Name = config.Name;
        Duration = config.Duration;
        StatusType = config.StatusType;
        TriggerConditions = config.TriggerConditions;
        Influences = config.Influences;
    }
}