using GameDataEditor;
using XSEngine.Core;

namespace XSEngine.Base
{
    /// <summary>
    /// 这一局游戏结束了，可以做一些显示结算，胜负，记录数据等等操作
    /// </summary>
    public class XSPhaseGameEnd : CorePhaseGameEnd
    {
        public static new CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseGameEnd<XSPhaseGameEnd>(); }

        public override void InitEvent()
        {
            base.InitEvent();
            // skill buff触发
            this.EventEmitter.On(Core.GameEventPhase.Event.ON_ENTER, mgr =>
                                XSBattleEmitter.Instance.Emit(TriggerDataTriggerBasicType.OnGameEnd, new XSReleaseData(mgr.PlayerMgr.GetCurPlayer() as XSPlayer)), 
                                Core.GameEventPhase.Priority.GameEnd.BATTLE_EMIT);
        }
    }
}