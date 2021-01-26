namespace XSEngine
{
    /// <summary>
    /// 游戏中的常量定义
    /// </summary>
    /// 
    public class Const
    {
        public static IConfig Config;
        public static void SetConfig(IConfig config) => Const.Config = config;
    }
}