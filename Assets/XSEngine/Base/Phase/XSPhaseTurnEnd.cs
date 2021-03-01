using XSEngine.Core;
using GameDataEditor;

namespace XSEngine.Base
{
    /// <summary>
    /// 当前玩家的回合结束，通知当前玩家回合结束，当前玩家做一些回合结束的操作（比如丢掉大于最大回手牌张数的牌到弃牌堆）
    /// 然后切换到下一个玩家，并切换到回合开始
    /// </summary>
    public class XSPhaseTurnEnd : CorePhaseTurnEnd
    {

        public static new CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseTurnEnd<XSPhaseTurnEnd>(); }

        public override void InitEvent()
        {
            base.InitEvent();
            // skill buff触发
            this.EventEmitter.On(Core.GameEventPhase.Event.ON_ENTER, 
                                mgr => XSBattleEmitter.Instance.Emit(TriggerDataTriggerBasicType.OnTurnEnd, new XSReleaseData(mgr.PlayerMgr.GetCurPlayer() as XSPlayer)),
                                Core.GameEventPhase.Priority.TurnEnd.BATTLE_EMIT);
        }
    }
}
