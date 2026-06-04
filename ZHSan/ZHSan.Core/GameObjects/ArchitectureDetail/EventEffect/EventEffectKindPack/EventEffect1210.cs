using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect1210 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Architecture arch, Event e)
    {
        var facilityKind = Session.Current.Scenario.GameCommonData.AllFacilityKinds.Get(eventEffect.GetIntParam());

        arch.BeginToBuildAFacility(facilityKind);
    }
}