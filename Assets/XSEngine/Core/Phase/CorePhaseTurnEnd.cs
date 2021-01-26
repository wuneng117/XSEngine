namespace XSEngine.Core
{
    /// <summary>
    /// 当前玩家的回合结束，通知当前玩家回合结束，当前玩家做一些回合结束的操作（比如丢掉大于最大回手牌张数的牌到弃牌堆）
    /// 然后切换到下一个玩家，并切换到回合开始
    /// </summary>
    public class CorePhaseTurnEnd : CorePhaseBase
    {
        /// <summary> 状态进入 </summary>
        public override void OnEnter<T>(T mgr)
        {
            base.OnEnter(mgr);
            var player = mgr.PlayerMgr.GetCurPlayer();
            player.OnTurnEnd();
            // 发送事件
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_TURNEND, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
            mgr.TurnBegin();
        }

        /// <summary> 状态退出 </summary>
        public override void OnExit<T>(T mgr)
        {
            mgr.PlayerMgr.SwitchPlayer();
        }
        // /// <summary> 预留接口，每帧更新 </summary>
        // public override void Update<T>(T mgr) {}
    }
}
