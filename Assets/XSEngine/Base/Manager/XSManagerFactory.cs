using System;
using XSEngine.Core;

namespace XSEngine.Base
{
    public class XSManagerFactory : CoreManagerFactory
    {
        // 游戏阶段
        public new static CorePhaseBase CreatePhaseGameStart<T>() where T : XSPhaseGameStart, new() => new T();
        public new static CorePhaseBase CreatePhaseGameEnd<T>() where T : XSPhaseGameEnd, new() => new T();
        public new static CorePhaseBase CreatePhaseTurnBegin<T>() where T : XSPhaseTurnBegin, new() => new T();
        public new static CorePhaseBase CreatePhaseTurnEnd<T>() where T : XSPhaseTurnEnd, new() => new T();

        /// <summary>
        /// 工厂模式创建BattleMgr
        /// </summary>override
        /// <returns></returns>
        public static new T CreateBattleMgr<T>(
            Action<CoreBattleMgrBase, CoreCardBase> ActionOnUseCard = null,
            Action<CoreBattleMgrBase> ActionOnGameStart = null,
            Action<CoreBattleMgrBase> ActionOnGameEnd = null,
            Action<CoreBattleMgrBase> ActionOnTurnBegin = null,
            Action<CoreBattleMgrBase> ActionOnTurnEnd = null,
            Func<CoreBattleMgrBase, bool> FuncCheckGameEnd = null
        ) where T : XSBattleMgr, new()
        {
            var ret = new T();
            ret.Init(ActionOnUseCard, ActionOnGameStart, ActionOnGameEnd, ActionOnTurnBegin, ActionOnTurnEnd, FuncCheckGameEnd);
            return ret;
        }
    }
}
