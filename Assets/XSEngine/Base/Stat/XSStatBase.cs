namespace XSEngine.Base
{
    /// <summary>
    /// 属性的集合，用来计算玩家属性
    /// </summary>
    public class XSStatBase
    {
        public HP Hp { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="hp"></param>
        public virtual bool Init(HP hp)
        {
            this.Hp = hp;
            return true;
        }

        /// <summary>
        /// 属性叠加
        /// </summary>
        /// <param name="add"></param>
        public virtual void Add(XSStatBase add)
        {   
            this.Hp.Add(add.Hp);
        }
    }
}
