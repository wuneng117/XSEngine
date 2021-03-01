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
        public virtual bool Init(
            Action<CoreBattleMgrBase, CoreCardBase> ActionOnUseCard = null,
            Action<CoreBattleMgrBase> ActionOnGameStart = null,
            Action<CoreBattleMgrBase> ActionOnGameEnd = null,
            Action<CoreBattleMgrBase> ActionOnTurnBegin = null,
            Action<CoreBattleMgrBase> ActionOnTurnEnd = null,
            Func<CoreBattleMgrBase, bool> FuncCheckGameEnd = null
        )
        {
            this.ActionOnUseCard = ActionOnUseCard;
            this.ActionOnGameStart = ActionOnGameStart;
            this.ActionOnGameEnd = ActionOnGameEnd;
            this.ActionOnTurnBegin = ActionOnTurnBegin;
            this.ActionOnTurnEnd = ActionOnTurnEnd;
            this.FuncCheckGameEnd = FuncCheckGameEnd;

            //phase类注册GameEvent
            CorePhaseGameStart.Instance.InitEvent();
            CorePhaseGameEnd.Instance.InitEvent();
            CorePhaseTurnBegin.Instance.InitEvent();
            CorePhaseTurnEnd.Instance.InitEvent();
            return true;
        }

        /// <summary> 用一张卡的回调 </summary>
        protected Action<CoreBattleMgrBase, CoreCardBase> ActionOnUseCard { get; set; }
        /// <summary>
        /// 用一张卡
        /// </summary>
        /// <param name="card">用的卡</param>
        public virtual void UseCard(CoreCardBase card)
        {
            this.ActionOnUseCard?.Invoke(this, card);
        }

        /// <summary>
        /// 是否当前玩家
        /// </summary>
        /// <param name="player">玩家</param>
        /// <return>返回是否</return>
        public bool IsCurPlayer(CorePlayerBase player) => this.PlayerMgr.GetCurPlayer() == player;

        /************************* 战斗阶段管理 begin ***********************/
        /// <summary> 游戏开始的回调 </summary>
        protected Action<CoreBattleMgrBase> ActionOnGameStart { get; set; }
        /// <summary> 游戏开始 </summary>
        public virtual void GameStart()
        {
            this.ActionOnGameStart?.Invoke(this);
            this.ChangeGameStart();
        }
        protected virtual void ChangeGameStart() => this.Change(CorePhaseGameStart.Instance, this);

        /// <summary>
        /// 尝试结束游戏
        /// </summary>
        public virtual void TryGameEnd()
        {
            if (this.CheckGameEnd())
                this.GameEnd();
        }

        /// <summary> 是否游戏结束的回调 </summary>
        protected Func<CoreBattleMgrBase, bool> FuncCheckGameEnd { get; set; }
        /// <summary> 是否游戏结束 </summary>
        public virtual bool CheckGameEnd()
        {
            var ret = this.FuncCheckGameEnd != null ? this.FuncCheckGameEnd(this) : false;
            return ret;
        }

        protected Action<CoreBattleMgrBase> ActionOnGameEnd { get; set; }
        /// <summary> 游戏结束 </summary>
        public virtual void GameEnd()
        {
            this.ActionOnGameEnd?.Invoke(this);
            this.ChangeGameEnd();
        }
        protected virtual void ChangeGameEnd() => this.Change(CorePhaseGameEnd.Instance, this);

        protected Action<CoreBattleMgrBase> ActionOnTurnBegin { get; set; }
        /// <summary> 回合开始 </summary>
        public virtual void TurnBegin()
        {
            this.ActionOnTurnBegin?.Invoke(this);
            this.AddRound();
            this.ChangeTurnBegin();
        }
        protected virtual void ChangeTurnBegin() => this.Change(CorePhaseTurnBegin.Instance, this);

        protected Action<CoreBattleMgrBase> ActionOnTurnEnd { get; set; }
        /// <summary> 回合结束 </summary>
        public virtual void TurnEnd()
        {
            this.ActionOnTurnEnd?.Invoke(this);
            this.ChangeTurnEnd();
        }
        protected virtual void ChangeTurnEnd() => this.Change(CorePhaseTurnEnd.Instance, this);
        /*************************  战斗阶段管理 end  ***********************/
    }
}