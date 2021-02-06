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
            CoreGameEventEmitter.Instance.On(GameEvent.Event.ON_GAME_START, mgr => mgr.PlayerMgr.OnGameStart(), GameEvent.Priority.GameStart.PLAYERMGR_ON_GAME_START);
        }

        /// <summary> 状态进入 </summary>
        public override void OnEnter<T>(T mgr)
        {
            base.OnEnter(mgr);
            CoreGameEventEmitter.Instance.Emit(GameEvent.Event.ON_GAME_START, mgr);
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_GAMESTART, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(-1));
        }

        // /// <summary> 状态退出 </summary>
        // public override void OnExit<T>(T mgr) {}
        /// <summary> 预留接口，每帧更新 </summary>
        public override void Update<T>(T mgr)
        {
            // 等OnEnter操作完成后切换到turnbegin
            mgr.TurnBegin();
        }
    }
}