namespace XSEngine.Base
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class XSTriggerFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建XSTriggerBase
        /// </summary>
        /// <param name="id">触发器id</param>
        /// <param name="name">触发器名字</param>
        /// <param name="name">触发器触发的对象</param>
        /// <returns></returns>
        public static T CreateTrigger<T>(int id, string name, XSIReleaseEntity releaseEntity) where T : XSTriggerBase, new()
        {
            var ret = new T();
            ret.Init(id, name, releaseEntity);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建XSTriggerNull
        /// </summary>
        /// <param name="id">触发器id</param>
        /// <param name="name">触发器触发的对象</param>
        /// <returns></returns>
        public static T CreateTriggerNull<T>(XSIReleaseEntity releaseEntity) where T : XSTriggerNull, new()
        {
            var ret = new T();
            ret.Init(-1, "TriggerNull", releaseEntity);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
