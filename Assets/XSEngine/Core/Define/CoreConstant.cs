namespace XSEngine.Core
{
    /// <summary>
    /// 全局配置
    /// </summary>
    /// 
    public class Const
    {
        /// <summary> 游戏中的常量定义 </summary>
        public static ICoreConfig Config;
        /// <summary> 设置常量参数 </summary>
        public static void SetConfig(ICoreConfig config) => Const.Config = config;
    }
}
