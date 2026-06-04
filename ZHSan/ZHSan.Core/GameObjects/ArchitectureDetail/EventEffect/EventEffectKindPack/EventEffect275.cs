using GameManager;
using GameObjects.PersonDetail;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect275 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        if (person.BelongedFaction != null && person.LocationArchitecture != null && person.BelongedCaptive == null)
        {
            var random = Random(Session.Current.Scenario.GameCommonData.AllPersonGeneratorTypes.Count);

            PersonGeneratorType type = Session.Current.Scenario.GameCommonData.AllPersonGeneratorTypes[random] as PersonGeneratorType;
            person.LocationArchitecture.GenerateOfficer(type, true);
        }
    }
}