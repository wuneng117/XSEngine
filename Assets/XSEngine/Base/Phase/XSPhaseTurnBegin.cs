
using GameDataEditor;
using XSEngine.Core;
namespace XSEngine.Base
{
    /// <summary>
    /// 玩家的回合开始，通知当前玩家回合开始，当前玩家做一些回合开始的操作（比如抽一张牌）
    /// </summary>
    public class XSPhaseTurnBegin : CorePhaseTurnBegin
    {
        public static new CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseTurnBegin<XSPhaseTurnBegin>(); }

        public override void InitEvent()
        {
            base.InitEvent();
            // skill buff触发
            this.EventEmitter.On(Core.GameEventPhase.Event.ON_ENTER, 
                                mgr => XSBattleEmitter.Instance.Emit(TriggerDataTriggerBasicType.OnTurnBegin, new XSReleaseData(mgr.PlayerMgr.GetCurPlayer() as XSPlayer)),
                                Core.GameEventPhase.Priority.TurnBegin.BATTLE_EMIT);
        }
    }
}
