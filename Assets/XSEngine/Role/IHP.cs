namespace XSEngine
{
    /// <summary> 血量魔法值属性的接口 </summary>
    public interface IHP
    {
        /// <summary> 基础属性 </summary>
        int Get();

        /// <summary> 加其它属性 </summary>
        bool Add(IHP hp);

        /// <summary> 加具体血量 </summary>
        void Add(int hp);

        /// <summary> 减具体血量 </summary>
        void Reduce(int hp);

        /// <summary> 获取最大血量 </summary>
        int GetMax();

        /// <summary> 获取最大血量属性 </summary>
        IAttr GetMaxAttr();

        /// <summary> 获取百分比：血量/最大血量 </summary>
        float GetPercent();
    }
}