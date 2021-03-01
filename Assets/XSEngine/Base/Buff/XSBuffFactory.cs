namespace XSEngine.Base
{
    public class XSBuffFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建XSBuffBase
        /// </summary>
        /// <param name="id">buffid</param>
        /// <param name="name">buff名字</param>
        /// <param name="player">所属玩家</param>
        /// <returns></returns>
        public static T CreateBuff<T>(int id, string name, XSPlayer player) where T : XSBuffBase, new()
        {
            var ret = new T();
            ret.Init(id, name, player);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
