namespace XSEngine.Core
{
    /// <summary>
    /// 卡牌，预留类型
    /// </summary>
    public class CoreCard : CoreCardBase
    {
    }

    /// <summary>
    /// 卡牌，就是代表了卡牌桌游里的一张牌
    /// </summary>
    public abstract class CoreCardBase
    {
        /// <summary> 卡牌id </summary>
        public int Id { get; protected set; } = 0;
        /// <summary> 卡牌名字 </summary>
        public string Name { get; protected set; } = "cardname";

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">卡牌id</param>
        /// <param name="name">卡牌名字</param>
        public virtual bool Init(int id, string name)
        {
            (this.Id, this.Name) = (id, name);
            return true;
        }
    }
}