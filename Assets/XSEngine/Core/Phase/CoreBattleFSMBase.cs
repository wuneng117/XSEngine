using UnityEngine;

namespace XSEngine.Core
{
    /// <summary>
    /// 状态机，管理游戏中各个阶段的转换，从而分解每个阶段的操作
    /// 目前基础的流程：
    /// GameStart 游戏开始 -> 玩家1 TurnBegin 玩家回合开始 -> 玩家1 TurnEnd 玩家回合结束 -> 玩家2 TurnBegin 玩家回合开始 ->...-> GameSEnd 游戏结束
    /// </summary>
    public abstract class CoreBattleFSMBase
    {
        /// <summary> 当前的阶段 </summary>
        public IPhaseBase Phase { get; protected set; }

        /// <summary>
        /// 切换阶段
        /// </summary>
        /// <param name="nextPhase"> 下个阶段 </param>
        /// <param name="mgr"> 游戏管理，作为参数传入，让阶段可以做一些操作 </param>
        public void Change<T>(IPhaseBase nextPhase, T mgr) where T : CoreBattleMgrBase
        {
            CoreFunc.Log("BattleFSM Change: " + this.Phase + "===>" + nextPhase);
            this.Phase?.OnExit(mgr);
            this.Phase = nextPhase;
            this.Phase.OnEnter(mgr);
        }

        /// <summary> 预留接口，每帧更新 </summary>
        public void Update<T>(T mgr) where T : CoreBattleMgrBase => this.Phase.Update(mgr);
    }
}