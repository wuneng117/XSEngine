namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class CoreFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        // ui事件
        public static CoreUIEmitter CreateUIEmitter() => new CoreUIEmitter();
        // ui事件传递数据data
        public static T CreateUIEmitterData<T>(int playerIndex)  where T : CoreUIEmitterData, new()
        {
            var ret = new T();
            ret.PlayerIndex = playerIndex;
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
