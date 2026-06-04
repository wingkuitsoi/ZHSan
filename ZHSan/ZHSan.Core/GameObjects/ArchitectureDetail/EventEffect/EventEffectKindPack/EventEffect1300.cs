using GameManager;
using System.Runtime.Serialization;

namespace GameObjects.ArchitectureDetail.EventEffect;

[DataContract]
public class EventEffect1300 : EventEffectKind
{
    public override void ApplyEffectKind(EventEffect eventEffect, Architecture arch, Event e)
    {
        var disaster = arch.zainan;
        var disasterKind = disaster.zainanzhonglei;
        
        disasterKind = Session.Current.Scenario.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei(eventEffect.GetIntParam());

        var range = disasterKind.shijianshangxian - disasterKind.shijianxiaxian;
        disaster.shengyutianshu = disasterKind.shijianxiaxian + Random(range);
        arch.youzainan = true;

        foreach (Military military in arch.Militaries)//发生灾难时不能补充
        {
            military.StopRecruitment();
        }
    }
}