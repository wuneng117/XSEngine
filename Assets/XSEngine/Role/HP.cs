namespace XSEngine
{
    /// <summary> 血量魔法值属性 </summary>
    public class HP : IHP
    {
        private int _val = 0;
        private Attr _max;

        public HP(int val = 0, Attr max = null)
        {
            this._val = val;
            this._max = max;
        }

        /// <summary> 基础属性 </summary>
        public int Get() => this._val;

        /// <summary> 加其它属性 </summary>
        public bool Add(IHP hp)
        {
            this._val += hp.Get();
            this._max.Add(hp.GetMaxAttr());
            return true;
        }

        /// <summary> 加具体血量 </summary>
        /// TODO 各种验证
        public void Add(int hp)
        {
            this._val += hp;
        }

        /// <summary> 减具体血量 </summary>
        /// TODO 各种验证
        public void Reduce(int hp)
        {
            this._val -= hp;
        }

        /// <summary> 获取最大血量 </summary>
        public int GetMax() => this._max.GetFinal();

        /// <summary> 获取最大血量属性 </summary>
        public IAttr GetMaxAttr() => this._max;

        /// <summary> 获取百分比：血量/最大血量 </summary>
        public float GetPercent() => this._val / this.GetMax();
    }
}