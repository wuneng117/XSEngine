using System;
using UnityEngine;

namespace XSEngine
{
    public class CostItem : CostItemBase
    {
    }

    /// <summary>
    /// 可用组件
    /// 费用资源，相当于炉石的法力水晶
    /// </summary>
    public abstract class CostItemBase
    {
        /// <summary> 当前上限 </summary>
        public int Limit { get; protected set; } = 0;

        /// <summary> 当前剩余值 </summary>
        public int Val { get; protected set; } = 0;

        /// <summary> 构造函数 </summary>
        public CostItemBase()
        {
            this.Limit = Const.Config.MONEY_LIMIT_INIT;
            this.Val = 0;  // 起始是没有可以用的
        }

        /// <summary> 回复费用到最大值 </summary>
        public void Recover() => this.Val = this.Limit;

        /// <summary> 上限+val </summary>
        public void addLimit(int val) => this.Limit = Mathf.Clamp(this.Limit + val, 0, Const.Config.MONEY_LIMIT_MAX);

        /// <summary> 是否达到上限 </summary>
        public bool IsMax() => this.Limit == Const.Config.MONEY_LIMIT_MAX;

        /// <summary> 费用够不够 </summary>
        public bool CanCost(int cost) => this.Val >= cost;

        /// <summary> 消耗费用 </summary>
        public void Cost(int cost) => this.Val = Math.Max(this.Val - cost, 0);
    }
}
