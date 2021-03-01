namespace XSEngine.Core
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class CoreFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        // GameEvent事件
        public static CoreGameEventEmitter CreateGameEventEmitter() => new CoreGameEventEmitter();
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
