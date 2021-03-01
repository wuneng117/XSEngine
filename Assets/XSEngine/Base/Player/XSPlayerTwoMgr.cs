using XSEngine.Core;

namespace XSEngine.Base
{
    /// <summary> 2个玩家模式下的所有玩家管理，可以直接获取单个敌人玩家 </summary>
    public class XSPlayerTwoMgr : CorePlayerMgrBase
    {
        /// <summary> 获取敌对玩家 </summary>
        public XSPlayer GetEnemyPlayer() => this.PlayerArray.Find((player) => player != this.PlayerArray[this.CurIndex]) as XSPlayer;
    }
}