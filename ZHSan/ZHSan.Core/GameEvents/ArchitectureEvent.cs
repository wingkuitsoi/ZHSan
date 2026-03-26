using System.Collections.Generic;
using GameObjects;

namespace GameEvents;

/// <summary>
/// 宴请事件
/// </summary>
/// <param name="inviter">邀请人</param>
/// <param name="invitees">受邀人</param>
public record EntertainEvent(Person inviter, List<Person> invitees);
