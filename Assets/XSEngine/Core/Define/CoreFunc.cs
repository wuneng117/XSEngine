namespace XSEngine.Core
{
    /// <summary>
    /// 全局常用方法
    /// </summary>
    public class CoreFunc
    {
        /// <summary>
        /// 打印日志统一入口
        /// </summary>
        /// <param name="message"></param>
        public static void Log(object message)
        {
           if (Const.Config.ISLOG) UnityEngine.Debug.Log(message);
        }
    }
}
