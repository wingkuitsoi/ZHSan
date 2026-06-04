using GameManager;
using GameObjects.PersonDetail;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect310 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Person person, Event e)
    {
        var title = Session.Current.Scenario.GameCommonData.AllTitles.GetTitle(eventEffect.GetIntParam());
        if (title == null) return;

        person.LearnTitle(title);
    }
}