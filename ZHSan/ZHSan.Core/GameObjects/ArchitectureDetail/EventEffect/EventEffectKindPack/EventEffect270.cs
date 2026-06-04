using GameManager;
using GameObjects.PersonDetail;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect270 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        if (person.BelongedFaction != null && person.LocationArchitecture != null && person.BelongedCaptive == null)
        {
            PersonGeneratorType type = Session.Current.Scenario.GameCommonData.AllPersonGeneratorTypes[eventEffect.GetIntParam()] as PersonGeneratorType;
            person.LocationArchitecture.GenerateOfficer(type, true);
        }
    }
}