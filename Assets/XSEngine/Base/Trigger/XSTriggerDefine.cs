/// <summary>
/// 用GameDataEditor命名空间，这样枚举类型可以给GDE用的
/// </summary>
namespace GameDataEditor
{
    /// <summary>
    /// 触发器触发类型
    /// </summary>
    public enum TriggerDataTriggerBasicType
    {
        None = 0,
        /// <summary>回合开始触发</summary>
        OnTurnBegin,  
        /// <summary>回合结束触发</summary>
        OnTurnEnd,      
        /// <summary>游戏开始触发</summary>
        OnGameStart,  
        /// <summary>游戏结束触发</summary>
        OnGameEnd,   
        /// <summary>攻击前触发</summary>
        BeforeAttack, 
        /// <summary>攻击后触发</summary>
        AfterAttack,
    }

    public enum TriggerDataTriggerTarget
    {
        /// <summary>不需要判断自己是哪个触发对象</summary>
        None = 0,
        /// <summary>自己是触发的src</summary>
        Src = 1,
        /// <summary>自己是触发的dst</summary>
        Dst = 2,
    }
}