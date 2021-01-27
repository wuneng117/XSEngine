namespace XSEngine
{
    /// <summary> 攻击啊防御属性的接口 </summary>
    public interface IAttr
    {
        /// <summary> 基础属性 </summary>
        int GetBase();

        /// <summary> 加成百分比 </summary>
        float GetFactor();

        /// <summary> 基础乘以百分比计算最终属性 </summary>
        int GetFinal();

        /// <summary> 加其它属性 </summary>
        bool Add(IAttr attr);
    }
}