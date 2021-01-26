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
        /// <returns></returns>
        public static T CreateCard<T>(int id, string name) where T : CoreCardBase, new()
        {
            var ret = new T();
            ret.Init(id, name);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建CardDeck
        /// </summary>
        /// <returns></returns>
        public static T CreateCardDeck<T>() where T : CoreCardDeckBase, new() => new T();

        /// <summary>
        /// 工厂模式创建CardList
        /// </summary>
        /// <returns></returns>
        public static T CreateCardList<T>() where T : CoreCardListBase, new() => new T();
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
