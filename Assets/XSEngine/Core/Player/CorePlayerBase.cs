using System;
using System.Diagnostics;
namespace XSEngine.Core
{
    /// <summary>
    /// 玩家,预留类型
    /// </summary>
    public class CorePlayer : CorePlayerBase
    {
    }

    /// <summary>
    /// 玩家自己的管理
    /// </summary>
    public abstract class CorePlayerBase
    {
        /// <summary> 玩家名字 </summary>
        public string Name { get; protected set; } = "test";

        /// <summary> 玩家序号 </summary>
        public int Index { get; protected set; } = -1;

        /// <summary> 玩家做一些游戏操作的接口 </summary>
        protected CoreITurnTrigger TurnTrigger { get; set; }

        protected CoreCardDeckBase Deck { get; } = CoreCardFactory.CreateCardDeck<CoreCardDeck>(); // 牌组
        public CoreCardDeckBase PublicDeck { get; set; } // 公共牌组
        public CoreCardListBase HandCards { get; } = CoreCardFactory.CreateCardList<CoreCardList>(); // 手牌
        public CoreCardListBase PlayAreaCards { get; set; } = CoreCardFactory.CreateCardList<CoreCardList>();// 出牌区
        protected CoreCardListBase DisCards { get; } = CoreCardFactory.CreateCardList<CoreCardList>(); // 弃牌堆

        /// <summary> 初始化 </summary>
        /// <param name="turnTrigger">玩家做一些游戏操作的接口</param>
        public virtual bool Init(int index,
                                CoreITurnTrigger turnTrigger,
                                CoreCardDeckBase publicDeck = null,
                                Func<CorePlayerBase, CoreCardBase, bool> FuncCanUseCard = null,
                                Action<CorePlayerBase, CoreCardBase> ActionOnUseCard = null,
                                Action<CorePlayerBase> ActionOnGameStart = null,
                                Action<CorePlayerBase> ActionOnGameEnd = null,
                                Action<CorePlayerBase> ActionOnTurnBegin = null,
                                Action<CorePlayerBase> ActionOnTurnEnd = null
        )
        {
            Debug.Assert(turnTrigger != null);
            (this.Name, this.Index, this.TurnTrigger) = ("No." + index, index, turnTrigger);
            this.PublicDeck = publicDeck ?? CoreCardFactory.CreateCardDeck<CoreCardDeck>();
            this.FuncCanUseCard = FuncCanUseCard;
            this.ActionOnUseCard = ActionOnUseCard;
            this.ActionOnGameStart = ActionOnGameStart;
            this.ActionOnGameEnd = ActionOnGameEnd;
            this.ActionOnTurnBegin = ActionOnTurnBegin;
            this.ActionOnTurnEnd = ActionOnTurnEnd;
            return true;
        }

        /// <summary> 是否当前玩家 </summary>
        public bool IsCurPlayer() => this.TurnTrigger.IsCurPlayer(this);

        /// <summary>
        /// 丢一张卡到弃牌堆
        /// </summary>
        /// <param name="card"></param>
        protected void DisCard(CoreCardBase card)
        {
            this.DisCards.Add(card);
            CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_DISCARDS_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(this.Index));
        }

        /// <summary>
        /// 能不能用这张卡
        /// </summary>
        /// <param name="card"></param>
        protected Func<CorePlayerBase, CoreCardBase, bool> FuncCanUseCard { get; set; }
        protected virtual bool CanUseCard(CoreCardBase card)
        {
            var ret = this.FuncCanUseCard != null ? this.FuncCanUseCard(this, card) : true;
            return ret;
        }

        /// <summary>
        /// 用一张卡
        /// </summary>
        /// <param name="card"></param>
        protected Action<CorePlayerBase, CoreCardBase> ActionOnUseCard { get; set; }
        public virtual void UseCard(CoreCardBase card)
        {
            if (!this.CanUseCard(card))
                return;

            this.ActionOnUseCard?.Invoke(this, card);
            this.TurnTrigger.UseCard(card);
        }
        /************************* 用户回合响应 begin ***********************/
        /// <summary> 游戏开始 </summary>
        protected Action<CorePlayerBase> ActionOnGameStart { get; set; }
        public virtual void OnGameStart()
        {
            this.ActionOnGameStart?.Invoke(this);
        }

        /// <summary> 你的回合开始 </summary>
        protected Action<CorePlayerBase> ActionOnTurnBegin { get; set; }
        public virtual void OnTurnBegin()
        {
            this.ActionOnTurnBegin?.Invoke(this);
        }

        /// <summary> 你的回合结束 </summary>
        protected Action<CorePlayerBase> ActionOnTurnEnd { get; set; }
        public virtual void OnTurnEnd()
        {
            this.ActionOnTurnEnd?.Invoke(this);
        }

        /// <summary> 游戏结束 </summary>
        protected Action<CorePlayerBase> ActionOnGameEnd { get; set; }
        public virtual void OnGameEnd()
        {
            this.ActionOnGameEnd?.Invoke(this);
        }
        /************************* 用户回合响应  end  ***********************/

        /************************* 用户操作 begin ***********************/

        /// <summary> 你结束你的回合 </summary>
        public void TurnEnd() => this.TurnTrigger.TurnEnd();

        /// <summary> 看看游戏是不是结束了 </summary>
        public void TryGameEnd() => this.TurnTrigger.TryGameEnd();
        /************************* 用户操作  end  ***********************/

    }
}