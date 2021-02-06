namespace XSEngine.Core
{
    /// <summary>
    /// 这一局游戏结束了，可以做一些显示结算，胜负，记录数据等等操作
    /// </summary>
    public class CorePhaseGameEnd : CorePhaseBase
    {
        protected static CorePhaseBase msInstance;
        public static CorePhaseBase Instance { get => msInstance = msInstance ?? CoreManagerFactory.CreatePhaseGameEnd<CorePhaseGameEnd>(); }
        
        /// <summary> 注册GameEvent </summary>
        public override void InitEvent()
        {
            base.InitEvent();
            this.EventEmitter.On(GameEventPhase.Event.ON_ENTER, mgr => CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYER_GAME_END, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(-1)),  GameEventPhase.Priority.GameEnd.UI);
        }
    }
}