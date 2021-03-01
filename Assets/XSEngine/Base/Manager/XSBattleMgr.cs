using System;
using XSEngine.Core;
namespace XSEngine.Base
{
    /// <summary> 
    /// 战斗管理类，负责战斗部分的全部管理
    ///  </summary>
    public class XSBattleMgr : CoreBattleMgrBase, CoreITurnTrigger
    {
        /************************* 战斗阶段管理 begin ***********************/
        protected override void ChangeGameStart() => this.Change(XSPhaseGameStart.Instance, this);

        /// <summary> 是否游戏结束 </summary>
        public override bool CheckGameEnd() => false;

        protected override void ChangeGameEnd() => this.Change(XSPhaseGameEnd.Instance, this);

        protected override void ChangeTurnBegin() => this.Change(XSPhaseTurnBegin.Instance, this);

        protected override void ChangeTurnEnd() => this.Change(XSPhaseTurnEnd.Instance, this);
        /*************************  战斗阶段管理 end  ***********************/
    }
}