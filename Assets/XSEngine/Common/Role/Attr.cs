namespace XSEngine
{
    /// <summary> 攻击啊防御属性 </summary>
    public class Attr : IAttr
    {
        private int _val = 0;
        private float _factor = 0;

        public Attr(int val = 0, float factor = 0)
        {
            this._val = val;
            this._factor = factor;
        }

        /// <summary> 基础属性 </summary>
        public int GetBase() => this._val;

        /// <summary> 加成百分比 </summary>
        public float GetFactor() => this._factor;

        /// <summary> 基础乘以百分比计算最终属性 </summary>
        public int GetFinal() => (int)(this._val * (1 + this._factor));

        /// <summary> 加其它属性 </summary>
        public bool Add(IAttr attr)
        {
            if (attr == null)
                return false;
                
            this._val += attr.GetBase();
            this._factor += attr.GetFactor();
            return true;
        }

        /// <summary> 加其它属性 </summary>
        public bool Add(int val, float factor = 0.0f)
        {
            this._val += val;
            this._factor += factor;
            return true;
        }
    }
}