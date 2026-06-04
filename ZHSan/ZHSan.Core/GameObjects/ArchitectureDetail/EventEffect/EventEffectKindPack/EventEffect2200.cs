using GameManager;
using System.Runtime.Serialization;
using GameObjects.FactionDetail;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect2200 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Faction faction, Event e)
    {
        var increment = eventEffect.GetIntParam();

        if (faction != null && Session.Current.Scenario.DiplomaticRelations != null)
        {
            GameObjectList relations = Session.Current.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(faction.ID);

            foreach (DiplomaticRelation i in relations)
            {
                i.Relation += increment;
            }
        }
    }
}