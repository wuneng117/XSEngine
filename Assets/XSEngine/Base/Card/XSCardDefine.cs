/// <summary>
/// 用GameDataEditor命名空间，这样枚举类型可以给GDE用的
/// </summary>
namespace GameDataEditor
{
    /// <summary>
    /// 卡牌类型
    /// </summary>
    public enum CardDataCardType
    {
        /// <summary>无</summary>
        None = 0,
        /// <summary>加热法, 加护法</summary>
        Extra = 1,
        /// <summary>物理卡</summary>
        PhysicsAttack = 2,
        /// <summary>魔法攻击</summary>
        MagicAttack = 3,
        /// <summary>辅助卡</summary>
        Assist = 4,
        /// <summary>布石</summary>
        Trap = 5,
    }
}
