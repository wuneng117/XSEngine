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

        /// <summary> 起始玩家对象,需要判断为空,有的卡牌没有玩家对象 </summary>
        public CorePlayerBase SrcPlayer { get; protected set; }        
        
        /// <summary> 当前玩家对象,需要判断为空,有的卡牌没有玩家对象 </summary>
        public CorePlayerBase CurPlayer { get; set; }
        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">卡牌id</param>
        /// <param name="name">卡牌名字</param>
        /// <param name="player">所属玩家</param>
        public virtual bool Init(int id, string name, CorePlayerBase player)
        {
            (this.Id, this.Name, this.SrcPlayer, this.CurPlayer) = (id, name, player, player);
            return true;
        }
    }
}