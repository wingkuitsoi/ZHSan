using GameManager;
using System.Runtime.Serialization;
using GameObjects.Influences;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect2020 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Faction faction, Event e)
    {
        var techniqueId = eventEffect.GetIntParam();

        var technique = Session.Current.Scenario.GameCommonData.AllTechniques.GetTechnique(techniqueId);
        faction.AvailableTechniques.AddTechnique(technique);

        Session.Current.Scenario.NewInfluence = true;
        technique.Influences.ApplyInfluence(faction, Applier.Technique, techniqueId);
        Session.Current.Scenario.NewInfluence = false;
    }
}