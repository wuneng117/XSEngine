namespace XSEngine.Core
{
    /// <summary>
    /// 当前玩家的回合结束，通知当前玩家回合结束，当前玩家做一些回合结束的操作（比如丢掉大于最大回手牌张数的牌到弃牌堆）
    /// 然后切换到下一个玩家，并切换到回合开始
    /// </summary>
    public class CorePhaseTurnEnd : CorePhaseBase
    {
        protected static CorePhaseBase msInstance;
        public static CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseTurnEnd<CorePhaseTurnEnd>(); }

        /// <summary> 注册GameEvent </summary>
        public override void InitEvent()
        {
            base.InitEvent();
            // 通知当前玩家onturnend
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr =>
            {
                var player = mgr.PlayerMgr.GetCurPlayer();
                player.OnTurnEnd();
            }, GameEventPhase.Priority.TurnEnd.CURPLAYER_ON_TURN_END);

            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, 
                                mgr => UIEmitter.Instance.Emit(UIEmitter.UI_PLAYER_TURN_END, UIEmitterFactory.CreateUIEmitterData<UIEmitterData>(mgr.PlayerMgr.GetCurPlayer()?.Index)), 
                                GameEventPhase.Priority.GameStart.UI);

            // 等OnEnter操作完成后切换到turnbegin
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr =>
            {
                mgr.PlayerMgr.SwitchPlayer();
                mgr.TurnBegin();
            }, GameEventPhase.Priority.TurnEnd.PHASE_CHANGE);
        }
    }
}
