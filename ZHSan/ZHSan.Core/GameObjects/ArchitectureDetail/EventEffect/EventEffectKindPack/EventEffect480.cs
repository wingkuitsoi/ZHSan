using GameManager;
using System.Runtime.Serialization;
using GameObjects.PersonDetail;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect480 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        person.IdealTendency = (IdealTendencyKind)Session.Current.Scenario.GameCommonData.AllIdealTendencyKinds.GetGameObject(eventEffect.GetIntParam());
    }
}