using System;
using System.Collections.Generic;

namespace XSEngine.Core
{
    /// <summary>
    /// 预留类型
    /// </summary>
    public class CoreCardDeck : CoreCardDeckBase
    {
    }

    /// <summary>
    /// 卡组和手牌有些不一样，类似栈，牌组底index为0，牌组顶index为count-1，回合开始抽卡时从牌组顶开始抽，
    /// 放入牌组也是从牌组顶，所以会经常洗牌
    /// </summary>
    public abstract class CoreCardDeckBase : CoreCardListBase
    {
        /// <summary>
        /// 从牌组顶开始抽一些卡
        /// </summary>
        /// <returns>被抽掉的一些卡</returns>
        public List<CoreCardBase> RemoveTop(int count = 1)
        {
            count = Math.Min(count, this.CardArray.Count);
            var beginIndex = this.CardArray.Count - count;
            var cards = this.CardArray.GetRange(beginIndex, count);
            this.CardArray.RemoveRange(beginIndex, count);
            cards.ForEach(card => card.CurPlayer = null);
            return cards;
        }

        /// <summary>
        /// 牌组底放入一张卡
        /// </summary>
        /// <param name="card">放入的一张卡</param>
        public void AddBottom(CoreCardBase card)
        {
            if (card != null)
            {
                this.CardArray.Insert(0, card);
                card.CurPlayer = this.Player;
            }
        }

        /// <summary>
        /// 牌组底放入一些卡
        /// </summary>
        /// <param name="cards">放入的一些卡</param>
        public void AddBottom(List<CoreCardBase> cards)
        {
            this.CardArray.InsertRange(0, cards);
            cards.ForEach(card => card.CurPlayer = this.Player);
        }
    }
}
