using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect325 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        var stuntId = eventEffect.GetIntParam();
        var stunt = Session.Current.Scenario.GameCommonData.AllStunts.GetStunt(stuntId);
        person.Stunts.Stunts.Remove(stuntId);
    }
}