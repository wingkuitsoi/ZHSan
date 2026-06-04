using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect2050 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Faction faction, Event e)
    {
        faction.BaseMilitaryKinds.RemoveMilitaryKind(eventEffect.GetIntParam());
    }
}