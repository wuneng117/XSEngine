using System;

namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class CoreManagerFactory
    {
        // 游戏阶段
        public static CorePhaseBase CreatePhaseGameStart<T>() where T : CorePhaseGameStart, new() => new T();
        public static CorePhaseBase CreatePhaseGameEnd<T>() where T : CorePhaseGameEnd, new() => new T();
        public static CorePhaseBase CreatePhaseTurnBegin<T>() where T : CorePhaseTurnBegin, new() => new T();
        public static CorePhaseBase CreatePhaseTurnEnd<T>() where T : CorePhaseTurnEnd, new() => new T();

        /// <summary>
        /// 工厂模式创建BattleMgr
        /// </summary>
        /// <returns></returns>
        public static T CreateBattleMgr<T>(
            Action<CoreBattleMgrBase, CoreCardBase> ActionOnUseCard = null,
            Action<CoreBattleMgrBase> ActionOnGameStart = null,
            Action<CoreBattleMgrBase> ActionOnGameEnd = null,
            Action<CoreBattleMgrBase> ActionOnTurnBegin = null,
            Action<CoreBattleMgrBase> ActionOnTurnEnd = null,
            Func<CoreBattleMgrBase, bool> FuncCheckGameEnd = null
        ) where T : CoreBattleMgrBase, new()
        {
            var ret = new T();
            ret.Init(ActionOnUseCard, ActionOnGameStart, ActionOnGameEnd, ActionOnTurnBegin, ActionOnTurnEnd, FuncCheckGameEnd);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
