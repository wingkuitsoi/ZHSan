using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect400 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        person.Character = Session.Current.Scenario.GameCommonData.AllCharacterKinds[eventEffect.GetIntParam()];
    }
}