using UnityEngine;
namespace XSEngine {
    public interface IConfig
    {
        int MONEY_LIMIT_INIT { get; }
        int MONEY_LIMIT_MAX { get; }
    }

    /// <summary>
    /// 游戏中的常量定义
    /// </summary>
    public class Config : MonoBehaviour, IConfig
    {
        /// <summary> money默认起始值 </summary>
        public int mONEY_LIMIT_INIT = 5;
        public int MONEY_LIMIT_INIT { get => mONEY_LIMIT_INIT; }
        /// <summary> money默认最大值 </summary>
        public int mONEY_LIMIT_MAX = 10;
        public int MONEY_LIMIT_MAX { get => mONEY_LIMIT_MAX; }
    }
}
