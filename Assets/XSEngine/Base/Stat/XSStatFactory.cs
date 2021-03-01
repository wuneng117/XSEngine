using XSEngine.Core;

namespace XSEngine.Base
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class XSStatFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建XSStatBase
        /// </summary>
        /// <param name="hp">血量</param>
        /// <returns></returns>
        public static T CreateStat<T>(HP hp) where T : XSStatBase, new()
        {
            var ret = new T();
            ret.Init(hp);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
