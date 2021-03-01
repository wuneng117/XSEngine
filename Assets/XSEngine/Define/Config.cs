using UnityEngine;
namespace XSEngine {

    /// <summary>
    /// 游戏中的常量定义
    /// </summary>
    public partial class Config : MonoBehaviour
    {
        /// <summary> money默认起始值 </summary>
        public int mONEY_LIMIT_INIT = 5;
        public int MONEY_LIMIT_INIT { get => mONEY_LIMIT_INIT; }
        /// <summary> money默认最大值 </summary>
        public int mONEY_LIMIT_MAX = 10;
        public int MONEY_LIMIT_MAX { get => mONEY_LIMIT_MAX; }
    }
}
