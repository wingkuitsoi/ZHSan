using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect500 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        var treasure = Session.Current.Scenario.Treasures.GetGameObject(eventEffect.GetIntParam()) as Treasure;

        if (treasure.BelongedPerson != null)
        {
            treasure.BelongedPerson.LoseTreasure(treasure);
        }

        person.ReceiveTreasure(treasure);
    }
}