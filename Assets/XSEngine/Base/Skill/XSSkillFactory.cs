namespace XSEngine.Base
{
    /// <summary>
    /// 用单例实现的抽象工厂模式去创建对象
    /// </summary>
    public class XSSkillFactory
    {
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/
        /// <summary>
        /// 工厂模式创建XSSkillBase
        /// </summary>
        /// <param name="id">技能id</param>
        /// <param name="name">技能名字</param>
        /// <param name="player">玩家</param>
        /// <returns></returns>
        public static T CreateSkill<T>(int id, string name, XSPlayer player) where T : XSSkillBase, new()
        {
            var ret = new T();
            ret.Init(id, name, player);
            return ret;
        }

        /// <summary>
        /// 工厂模式创建XSSkillNull
        /// </summary>
        /// <param name="id">触发器id</param>
        /// <param name="name">触发器触发的对象</param>
        /// <returns></returns>
        public static T CreateSkillNull<T>(XSPlayer player) where T : XSSkillNull, new()
        {
            var ret = new T();
            ret.Init(-1, "SkillNull", player);
            return ret;
        }
        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
