using System;
using System.Collections.Generic;
namespace XSEngine.Core
{
    /// <summary>
    /// 预留类型
    /// </summary>
    public class CoreCardList : CoreCardListBase
    {
    }

    /// <summary>
    /// 由一些卡牌组成的特定区域，比如牌组，手牌，弃牌堆
    /// </summary>
    /// <typeparam name="ICardBase"></typeparam>
    public abstract class CoreCardListBase
    {
        /// <summary> 列表里的卡 </summary>
        public List<CoreCardBase> CardArray { get; } = new List<CoreCardBase>();

        /// <summary> 当前所属玩家,没有的话为null </summary>
        public CorePlayerBase Player {get; protected set; }

        /// <summary>
        /// CardArray.Count的最大值
        /// </summary>
        /// <param name="card"></param>
        public Func<int> FuncCountMax { protected get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="player">当前所属玩家</param>
        /// <returns></returns>
        public virtual bool Init(CorePlayerBase player)
        {
            this.Player = player;
            return true;
        }

        /// <summary>
        /// 能不能放入这张卡
        /// </summary>
        /// <param name="card">放入的卡</param>
        /// <returns>能不能呢</returns>
        public virtual bool CanAdd(CoreCardBase card) => this.FuncCountMax == null ? true : this.Count + 1 <= this.FuncCountMax();

        /// <summary>
        /// 能不能放入一些卡
        /// </summary>
        /// <param name="cards">放入的一些卡</param>
        /// <returns>能不能呢</returns>
        public virtual bool CanAdd(List<CoreCardBase> cards) => this.FuncCountMax == null ? true : this.Count + cards.Count <= this.FuncCountMax();
        
        /// <summary> 洗牌 </summary>
        public void Shuffle() => this.CardArray.Shuffle();

        /// <summary>
        /// 够不够丢卡
        /// </summary>
        /// <param name="count">丢卡的数量</param>
        /// <returns>能不能呢</returns>
        public bool CanRemove(int count) => this.CardArray.Count >= count;

        /// <summary>
        /// 随机丢卡
        /// </summary>
        /// <param name="count">丢卡的数量</param>
        /// <returns>丢掉的一些卡</returns>
        public List<CoreCardBase> RandomRemove(int count)
        {
            var ret = new List<CoreCardBase>();
            for (var i = 0; i < count; i++)
            {
                if (this.CardArray.Count <= 0)
                    break;

                var index = ThreadSafeRandom.ThisThreadsRandom.Next(this.CardArray.Count);
                this.CardArray[index].CurPlayer = null;
                ret.Add(this.CardArray[index]);
                this.CardArray.RemoveAt(index);
            }

            return ret;
        }

        /************************* 封装list begin ***********************/
        public int Count { get => this.CardArray.Count; }

        public void Add(CoreCardBase card) 
        { 
            if (card != null) 
            {
                this.CardArray.Add(card); 
                card.CurPlayer = this.Player;
            }
        }

        public void Add(List<CoreCardBase> cards) 
        {
             this.CardArray.AddRange(cards);
             cards.ForEach(card => card.CurPlayer = this.Player);
        }

        public void Clear() => this.CardArray.Clear();
        public bool Contains(CoreCardBase card) => this.CardArray.Contains(card);
        public bool Exists(Predicate<CoreCardBase> match) => this.CardArray.Exists(match);
        public CoreCardBase Find(Predicate<CoreCardBase> match) => this.CardArray.Find(match);
        public List<CoreCardBase> FindAll(Predicate<CoreCardBase> match) => this.CardArray.FindAll(match);
        public void ForEach(Action<CoreCardBase> action) => this.CardArray.ForEach(action);
        public bool Remove(CoreCardBase card) => this.CardArray.Remove(card);
        public int RemoveAll(Predicate<CoreCardBase> match) => this.CardArray.RemoveAll(match);
        public void RemoveAt(int index) => this.CardArray.RemoveAt(index);
        public void RemoveRange(int index, int count) => this.CardArray.RemoveRange(index, count);
        public void Sort(Comparison<CoreCardBase> comparison) => this.CardArray.Sort(comparison);

        /************************* 封装list  end  ***********************/
    }
}