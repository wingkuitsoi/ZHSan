using GameManager;
using System.Runtime.Serialization;
using GameObjects.FactionDetail;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect2300 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Faction faction, Event e)
    {
        var increment = eventEffect.GetIntParam();

        var factionId = faction.ID;
        var scenario = Session.Current.Scenario;

        Faction otherFaction = scenario.Factions.GetGameObject(eventEffect.GetIntParam2()) as Faction;
        var otherFactionId = otherFaction.ID;

        GameObjectList relations = scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(factionId);
        foreach (DiplomaticRelation relation in relations)
        {
            if ((relation.RelationFaction1ID == factionId && relation.RelationFaction2ID == otherFactionId) || (relation.RelationFaction1ID == otherFactionId && relation.RelationFaction2ID == factionId))
            {
                scenario.ChangeDiplomaticRelation(factionId, otherFactionId, increment);
            }
        }
    }
}