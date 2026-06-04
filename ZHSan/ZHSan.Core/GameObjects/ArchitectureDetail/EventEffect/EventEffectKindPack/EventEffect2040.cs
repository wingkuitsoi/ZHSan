using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect2040 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Faction faction, Event e)
    {
        var militaryKind = Session.Current.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(eventEffect.GetIntParam());

        faction.BaseMilitaryKinds.AddMilitaryKind(militaryKind);
    }
}