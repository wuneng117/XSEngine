
namespace XSEngine.Core
{
    /// <summary>
    /// 玩家的回合开始，通知当前玩家回合开始，当前玩家做一些回合开始的操作（比如抽一张牌）
    /// </summary>
    public class CorePhaseTurnBegin : CorePhaseBase
    {
        protected static CorePhaseBase msInstance;
        public static CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseTurnBegin<CorePhaseTurnBegin>(); }

        /// <summary> 注册GameEvent </summary>
        public override void InitEvent()
        {
            base.InitEvent();
            CoreGameEventEmitter.Instance.On(GameEvent.Event.ON_TURN_BEGIN, mgr =>
            {
                var player = mgr.PlayerMgr.GetCurPlayer();
                player.OnTurnBegin();
            }, GameEvent.Priority.TurnBegin.CURPLAYER_ON_TURN_BEGIN);
        }

        /// <summary> 状态进入 </summary>
        public override void OnEnter<T>(T mgr)
        {
            base.OnEnter(mgr);
            CoreGameEventEmitter.Instance.Emit(GameEvent.Event.ON_TURN_BEGIN, mgr);
            var player = mgr.PlayerMgr.GetCurPlayer();
            // 发送事件
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_TURNBEGIN, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
        }

        // /// <summary> 状态退出 </summary>
        // public override void OnExit<T>(T mgr) {}
        // /// <summary> 预留接口，每帧更新 </summary>
        // public override void Update<T>(T mgr) {}
    }
}
