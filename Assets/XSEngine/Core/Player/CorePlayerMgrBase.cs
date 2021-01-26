using System.Collections.Generic;

namespace XSEngine.Core
{
    /// <summary>
    /// 预留类型
    /// </summary>
    public class CorePlayerMgr : CorePlayerMgrBase
    {
    }

    /// <summary>
    /// 玩家管理类，可以获取当前玩家，玩家之间回合的切换
    /// </summary>
    public abstract class CorePlayerMgrBase
    {
        /// <summary> 玩家数组 </summary>
        public List<CorePlayerBase> PlayerArray { get; } = new List<CorePlayerBase>();
        public virtual void AddPlayer(CorePlayerBase player) { if(player != null) this.PlayerArray.Add(player);} 
        /// <summary> 当前玩家序号 </summary>
        protected int CurIndex { get; set; } = -1;

        /// <summary> 获取当前玩家 </summary>
        public CorePlayerBase GetCurPlayer() => this.PlayerArray.Count <= this.CurIndex ? null : this.PlayerArray[this.CurIndex];

        /// <summary>
        /// 切换当前玩家
        /// </summary>
        /// <returns>是否一轮结束</returns>
        public bool SwitchPlayer() => (this.CurIndex = (this.CurIndex + 1) % this.PlayerArray.Count) == 0;

        /// <summary>
        /// 游戏开始
        /// </summary>
        public void OnGameStart()
        {
            this.PlayerArray.ForEach(player => player.OnGameStart());
            this.CurIndex = 0;
        }
    }
}