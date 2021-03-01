namespace XSEngine
{
    /// <summary>
    /// 游戏中的常量定义
    /// </summary>
    /// 
    public class Const
    {
        /// <summary> 游戏中的常量定义 </summary>
        public static Config Config;
        /// <summary> 设置常量参数 </summary>
        public static void SetConfig(Config config) => Const.Config = config;
    }
}