
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

            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr =>
            {
                var player = mgr.PlayerMgr.GetCurPlayer();
                player.OnTurnBegin();
            }, GameEventPhase.Priority.TurnBegin.CURPLAYER_ON_TURN_BEGIN);

            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr =>
            {
                var player = mgr.PlayerMgr.GetCurPlayer();
                CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_TURN_BEGIN, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
            },  GameEventPhase.Priority.TurnBegin.UI);
        }

        // /// <summary> 状态退出 </summary>
        // public override void OnExit<T>(T mgr) {}
        // /// <summary> 预留接口，每帧更新 </summary>
        // public override void Update<T>(T mgr) {}
    }
}
