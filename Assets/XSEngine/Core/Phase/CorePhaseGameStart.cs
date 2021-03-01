namespace XSEngine.Core
{
    /// <summary>
    /// 开始一局新的游戏，通知玩家游戏开始，玩家做一些初始化操作（比如拿起始手牌）
    /// </summary>
    public class CorePhaseGameStart : CorePhaseBase
    {
        protected static CorePhaseBase msInstance;
        public static CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseGameStart<CorePhaseGameStart>(); }

        /// <summary> 注册GameEvent </summary>
        public override void InitEvent()
        {
            base.InitEvent();
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr => mgr.PlayerMgr.OnGameStart(), GameEventPhase.Priority.GameStart.PLAYERMGR_ON_GAME_START);
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, 
                                mgr => UIEmitter.Instance.Emit(UIEmitter.UI_PLAYER_GAME_START, UIEmitterFactory.CreateUIEmitterData<UIEmitterData>(-1)),  
                                GameEventPhase.Priority.GameStart.UI);
            // 等操作完成后切换到turnbegin
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr => mgr.TurnBegin(),  GameEventPhase.Priority.GameStart.PHASE_CHANGE);
        }
    }
}