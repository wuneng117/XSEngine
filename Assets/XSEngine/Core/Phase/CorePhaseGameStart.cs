namespace XSEngine.Core {
    /// <summary>
    /// 开始一局新的游戏，通知玩家游戏开始，玩家做一些初始化操作（比如拿起始手牌）
    /// </summary>
    public class CorePhaseGameStart : CorePhaseBase {
        /// <summary> 状态进入 </summary>
        public override void OnEnter<T>(T mgr)
        {
            base.OnEnter(mgr);
            mgr.PlayerMgr.OnGameStart();
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_GAMESTART, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(-1));
            mgr.TurnBegin();
        }
        
        // /// <summary> 状态退出 </summary>
        // public override void OnExit<T>(T mgr) {}
        // /// <summary> 预留接口，每帧更新 </summary>
        // public override void Update<T>(T mgr) {}
    }
}