using System;
using UnityEngine;

namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// 玩家和游戏管理
    /// </summary>
    public class CorePlayerFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建
        /// </summary>
        /// <param name="index">玩家序号</param>
        /// <param name="turnTrigger">玩家做一些游戏操作的接口</param>
        /// <returns></returns>
        public static T CreatePlayer<T>(int index,
                                        CoreITurnTrigger turnTrigger,
                                        CoreCardDeckBase publicDeck = null,
                                        Func<CorePlayerBase, CoreCardBase, bool> FuncCanUseCard = null,
                                        Action<CorePlayerBase, CoreCardBase> ActionOnUseCard = null,
                                        Action<CorePlayerBase> ActionOnGameStart = null,
                                        Action<CorePlayerBase> ActionOnGameEnd = null,
                                        Action<CorePlayerBase> ActionOnTurnBegin = null,
                                        Action<CorePlayerBase> ActionOnTurnEnd = null
        ) where T : CorePlayer, new()
        {
            if (index < 0 || turnTrigger == null)
                return null;

            var ret = new T();
            ret.Init(index, turnTrigger, publicDeck, FuncCanUseCard, ActionOnUseCard, ActionOnGameStart, ActionOnGameEnd, ActionOnTurnBegin, ActionOnTurnEnd);
            // // 没有牌组，所有卡入手牌
            // role.GetCardIdArray().ForEach(id => this.HandCards.Add(BladeCard.Create(CardDataManager.Instance.GetItem(id))));
            return ret;
        }

        /// <summary>
        /// 工厂模式创建
        /// </summary>
        /// <returns></returns>
        public static T CreatePlayerMgr<T>() where T : CorePlayerMgr, new()
        {
            var ret = new T();
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
