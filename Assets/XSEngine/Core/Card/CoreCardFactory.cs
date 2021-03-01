namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class CoreCardFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建CoreCard
        /// </summary>
        /// <param name="id">卡牌id</param>
        /// <param name="name">卡牌名字</param>
        /// <param name="player">所属玩家</param>
        /// <returns></returns>
        public static T CreateCard<T>(int id, string name, CorePlayerBase player) where T : CoreCardBase, new()
        {
            var ret = new T();
            ret.Init(id, name, player);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建CardDeck
        /// </summary>
        /// <returns></returns>
        public static T CreateCardDeck<T>(CorePlayerBase player) where T : CoreCardDeckBase, new()
        {
            var ret = new T();
            ret.Init(player);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建CardList
        /// </summary>
        /// <returns></returns>
        public static T CreateCardList<T>(CorePlayerBase player) where T : CoreCardListBase, new()
        {
            var ret = new T();
            ret.Init(player);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
