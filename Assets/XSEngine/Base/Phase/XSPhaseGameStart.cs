
using XSEngine.Core;
using GameDataEditor;

namespace XSEngine.Base
{
    /// <summary>
    /// 开始一局新的游戏，通知玩家游戏开始，玩家做一些初始化操作（比如拿起始手牌）
    /// </summary>
    public class XSPhaseGameStart : CorePhaseGameStart
    {
        public static new CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseGameStart<XSPhaseGameStart>(); }

        public override void InitEvent()
        {
            base.InitEvent();
            // skill buff触发
            this.EventEmitter.On(Core.GameEventPhase.Event.ON_ENTER, 
                                mgr => XSBattleEmitter.Instance.Emit(TriggerDataTriggerBasicType.OnGameStart, new XSReleaseData()), 
                                Core.GameEventPhase.Priority.GameStart.BATTLE_EMIT);
        }
    }
}