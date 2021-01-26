namespace XSEngine.Core
{
    /// <summary>
    /// 这一局游戏结束了，可以做一些显示结算，胜负，记录数据等等操作
    /// </summary>
    public class CorePhaseGameEnd : CorePhaseBase
    {
        /// <summary> 状态进入 </summary>
        public override void OnEnter<T>(T mgr)
        {
            base.OnEnter(mgr);
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_GAMEEND, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(-1));
        }

        // /// <summary> 状态退出 </summary>
        // public override void OnExit<T>(T mgr) {}
        // /// <summary> 预留接口，每帧更新 </summary>
        // public override void Update<T>(T mgr) {}
    }
}