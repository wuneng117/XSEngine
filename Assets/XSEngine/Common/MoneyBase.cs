using System;

namespace XSEngine
{
    /// <summary>
    /// 可用组件
    /// 费用资源，相当于炉石的法力水晶
    /// </summary>
    public class MoneyBase
    {
        /// <summary> 当前上限 </summary>
        private int _limit = 0;
        public int GetLimit() => this._limit;

        /// <summary> 当前剩余值 </summary>
        private int _val = 0; 
        public int GetVal() => this._val;

        /// <summary> 构造函数 </summary>
        public MoneyBase()
        {
            this._limit = Const.Config.MONEY_LIMIT_INIT;
            this._val = 0;  // 起始是没有可以用的
        }

        /// <summary> 上限+1，并回复费用到最大值 </summary>
        public void Recover()
        {
            this._limit = Math.Min(this._limit + 1, Const.Config.MONEY_LIMIT_MAX);
            this._val = this._limit;
        }

        /// <summary> 费用够不够 </summary>
        public bool CanCost(int cost) => this._val >= cost;

        /// <summary> 消耗费用 </summary>
        public void Cost(int cost)
        {
            this._val = Math.Max(this._val - cost, 0);
        }
    }
}
