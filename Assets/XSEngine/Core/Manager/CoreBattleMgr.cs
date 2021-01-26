using System;

namespace XSEngine.Core
{
    /// <summary>
    /// 预留类型
    /// </summary>
    public class CoreBattleMgr : CoreBattleMgrBase
    {
    }

    /// <summary> 
    /// 战斗管理基类，负责战斗的全部管理
    ///  </summary>
    public abstract class CoreBattleMgrBase : CoreBattleFSMBase, CoreITurnTrigger
    {
        /// <summary> 统一管理玩家 </summary>
        public CorePlayerMgrBase PlayerMgr { get; protected set; }
        /// <summary> 设置玩家管理类 </summary>
        public void SetPlayerMgr(CorePlayerMgrBase mgr) => this.PlayerMgr = mgr;

        /// <summary> 回合数，所有玩家一次行动后加1 </summary>
        protected int _roundIndex = 0;
        /// <summary> 回合数+1 </summary>
        public void AddRound() => this._roundIndex++;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public virtual bool Init() => true;

        /// <summary> 用一张卡的回调 </summary>
        public Action<CoreCardBase> ActionOnUseCard { protected get; set; }
        /// <summary>
        /// 用一张卡
        /// </summary>
        /// <param name="card">用的卡</param>
        public virtual void UseCard(CoreCardBase card)
        {
            this.ActionOnUseCard?.Invoke(card);
        }

        /// <summary>
        /// 是否当前玩家
        /// </summary>
        /// <param name="player">玩家</param>
        /// <return>返回是否</return>
        public bool IsCurPlayer(CorePlayerBase player) => this.PlayerMgr.GetCurPlayer() == player;

        /************************* 战斗阶段管理 begin ***********************/
        /// <summary> 游戏开始的回调 </summary>
        public Action ActionOnGameStart { protected get; set; }
        /// <summary> 游戏开始 </summary>
        public virtual void GameStart()
        {
            this.ActionOnGameStart?.Invoke();
            this.Change<CoreBattleMgrBase>(CoreManagerFactory.CreatePhaseGameStart<CorePhaseGameStart>(), this);
        }

        /// <summary>
        /// 尝试结束游戏
        /// </summary>
        public virtual void TryGameEnd()
        {
            if (this.CheckGameEnd())
                this.GameEnd();
        }

        /// <summary> 是否游戏结束的回调 </summary>
        public Func<bool> FuncCheckGameEnd { protected get; set; }
        /// <summary> 是否游戏结束 </summary>
        public virtual bool CheckGameEnd()
        {
            var ret = this.FuncCheckGameEnd != null ? this.FuncCheckGameEnd() : false;
            return ret;
        }

        public Action ActionOnGameEnd { protected get; set; }
        /// <summary> 游戏结束 </summary>
        public virtual void GameEnd()
        {
            this.ActionOnGameEnd?.Invoke();
            this.Change<CoreBattleMgrBase>(CoreManagerFactory.CreatePhaseGameEnd<CorePhaseGameEnd>(), this);
        }

        public Action ActionOnTurnBegin { protected get; set; }
        /// <summary> 回合开始 </summary>
        public virtual void TurnBegin()
        {
            this.ActionOnTurnBegin?.Invoke();
            this.AddRound();
            this.Change<CoreBattleMgrBase>(CoreManagerFactory.CreatePhaseTurnBegin<CorePhaseTurnBegin>(), this);
        }

        public Action ActionOnTurnEnd { protected get; set; }
        /// <summary> 回合结束 </summary>
        public virtual void TurnEnd()
        {
            this.ActionOnTurnEnd?.Invoke();
            this.Change<CoreBattleMgrBase>(CoreManagerFactory.CreatePhaseTurnEnd<CorePhaseTurnEnd>(), this);
        }
        /*************************  战斗阶段管理 end  ***********************/
    }
}