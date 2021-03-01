/// <summary>
/// 用GameDataEditor命名空间，这样枚举类型可以给GDE用的
/// </summary>
namespace GameDataEditor
{
    /// <summary>
    /// 技能类型
    /// </summary>
    public enum SkillDataSkillType
    {
        Common = 0,
        /// <summary> 增加prop点攻击力 </summary>
        AddAttack,
        /// <summary> 消耗X点增加防御力 </summary>
        XAddDefence,
        /// <summary> 本回合获得prop点魔力值 </summary>
        AddVoltage,
    }
}