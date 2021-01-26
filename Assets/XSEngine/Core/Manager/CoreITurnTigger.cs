
namespace XSEngine.Core {
    /// <summary> 给玩家调用的转换阶段的接口 </summary>
    public interface CoreITurnTrigger {
        /// <summary> 回合结束 </summary>
        void TurnEnd();

        /// <summary>
        /// 用一张卡
        /// </summary>
        /// <param name="card">用的卡</param>
        void UseCard(CoreCardBase card);

        /// <summary>
        /// 是否当前玩家
        /// </summary>
        /// <param name="card">玩家</param>
        bool IsCurPlayer(CorePlayerBase player);
        
        /// <summary>
        /// 尝试结束游戏
        /// </summary>
        void TryGameEnd();

    }
}