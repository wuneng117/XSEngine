using UnityEngine;

namespace XSEngine.Core
{
    public interface ICoreConfig
    {
        int START_HAND_CARDS { get; }
        int PLAYER_NUM_DEFAULT { get; }
        int PLAYER_NUM_MIN { get; }
        int PLAYER_NUM_MAX { get; }
        bool ISLOG { get; }
    }

    /// <summary>
    /// 游戏中的常量定义
    /// 把这个脚本挂到场景节点上，通过脚本设置初始值，然后把这个脚本赋值给CoreConstant
    /// </summary>
    public class CoreConfig : MonoBehaviour, ICoreConfig
    {
        /// <summary> 起始手牌张数 </summary>
        public int sTART_HAND_CARDS = 5;
        public int START_HAND_CARDS { get => sTART_HAND_CARDS; }
        /// <summary> 默认人数 </summary>
        public int pLAYER_NUM_DEFAULT = 2;
        public int PLAYER_NUM_DEFAULT { get => pLAYER_NUM_DEFAULT; }
        /// <summary> 最小人数 </summary>
        public int pLAYER_NUM_MIN = 2;
        public int PLAYER_NUM_MIN { get => pLAYER_NUM_MIN; }
        /// <summary> 最大人数 </summary>
        public int pLAYER_NUM_MAX = 4;
        public int PLAYER_NUM_MAX { get => pLAYER_NUM_MAX; }

        /************************* 调试相关 begin ***********************/
        /// <summary> 是否打印调试信息 </summary>
        public bool iSLOG = true;
        public bool ISLOG { get => iSLOG; }

        /************************* 调试相关  end  ***********************/
    }
}
