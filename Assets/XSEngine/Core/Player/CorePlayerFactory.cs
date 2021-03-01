using System;

namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// 玩家和游戏管理
    /// </summary>
    public class CorePlayerFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        // GameEvent事件
        public static Emitter<GameEventPlayer.Event, Action> CreateGameEventPlayerEmitter() => new Emitter<GameEventPlayer.Event, Action>();

        // GameCardEvent事件
        public static Emitter<GameEventPlayer.CardEvent, Action<CoreCardBase>> CreateGamEventPlayeeCardrEmitter() => new Emitter<GameEventPlayer.CardEvent, Action<CoreCardBase>>();

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
        ) where T : CorePlayerBase, new()
        {
            if (index < 0 || turnTrigger == null)
                return null;

            var ret = new T();
            ret.Init(index, turnTrigger, publicDeck, FuncCanUseCard, ActionOnUseCard, ActionOnGameStart, ActionOnGameEnd, ActionOnTurnBegin, ActionOnTurnEnd);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建
        /// </summary>
        /// <returns></returns>
        public static T CreatePlayerMgr<T>() where T : CorePlayerMgrBase, new()
        {
            var ret = new T();
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
