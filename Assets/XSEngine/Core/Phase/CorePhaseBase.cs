namespace XSEngine.Core {
    public interface IPhaseBase
    {
        void OnEnter<T>(T mgr) where T : CoreBattleMgrBase;
        void OnExit<T>(T mgr) where T : CoreBattleMgrBase;
        void Update<T>(T mgr) where T : CoreBattleMgrBase;
    }

    /// <summary>
    /// 每个阶段是一个类专门处理，通过调用状态机BattleFSM的Change函数来做阶段切换
    /// 目前有OnEnter和OnExit2个接口，分2个是因为卡牌游戏经常有“在XX回合开始时”，“在xx回合结束时”这一类效果的触发
    /// </summary>
    public abstract class CorePhaseBase : IPhaseBase
    {
        /// <summary> 注册GameEvent </summary>
        public virtual void InitEvent() { }
        /// <summary> 状态进入 </summary>
        public virtual void OnEnter<T>(T mgr) where T : CoreBattleMgrBase { }
        /// <summary> 状态退出 </summary>
        public virtual void OnExit<T>(T mgr) where T : CoreBattleMgrBase { }
        /// <summary> 预留接口，每帧更新 </summary>
        public virtual void Update<T>(T mgr) where T : CoreBattleMgrBase { }
    }
}