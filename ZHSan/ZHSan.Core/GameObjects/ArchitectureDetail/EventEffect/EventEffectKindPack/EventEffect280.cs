using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect280 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        var factionlist = Session.Current.Scenario.Factions;
        var oldFaction = person.BelongedFaction;
        var mergeFaction = factionlist.GetGameObject(eventEffect.GetIntParam()) as Faction;

        if (oldFaction != null && mergeFaction != null && person == oldFaction.Leader)
        {
            oldFaction.ChangeFaction(mergeFaction);
            //oldFaction.Leader.InitialLoyalty();
        }
    }
}