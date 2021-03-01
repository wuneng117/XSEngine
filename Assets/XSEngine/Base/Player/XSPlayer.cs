using System.Collections.Generic;
using XSEngine.Core;

namespace XSEngine.Base
{
    /// <summary>
    /// 玩家自己的管理
    /// </summary>
    public class XSPlayer : CorePlayerBase
    {
        /// <summary> 玩家血量 </summary>
        protected HP Hp { get; set; } = new HP();

        /// <summary> 玩家身上的buff管理 </summary>
        protected List<XSBuffBase> BuffArray { get; set; } = new List<XSBuffBase>();

        /************************* 用户回合响应 begin ***********************/
        /// <summary> 游戏开始 </summary>
        protected override void InitOnGameStart()
        {
            base.InitOnGameStart();
            this.EventEmitter.On(Core.GameEventPlayer.Event.ON_GAME_START, () =>
            {
                // 洗牌，抽起始手牌
                this.Deck.Shuffle();
                this.HandCards.Add(this.Deck.RemoveTop(Const.Config.START_HAND_CARDS));
            }, Core.GameEventPlayer.Priority.GameStart.DRAW_CARD);
        }

        /************************* 用户回合响应  end  ***********************/
    }
}