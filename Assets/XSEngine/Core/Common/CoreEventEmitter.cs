using System;

namespace XSEngine.Core
{
    /// <summary> GameEvent </summary>
    public class CoreGameEventEmitter : Emitter<string, Action<CoreBattleMgrBase>>
    {
        private static CoreGameEventEmitter msInstance;
        public static CoreGameEventEmitter Instance { get => msInstance = msInstance ?? CoreFactory.CreateGameEventEmitter(); }
    }
    // public class GameEvent
    // {
    //     public static string PLAYER_ON_GAME_START = "PLAYER_ON_GAME_START";
    //     public static string PLAYER_ON_GAME_END = "PLAYER_ON_GAME_END";
    //     public static string PLAYER_ON_TURN_BEGIN = "PLAYER_ON_TURN_BEGIN";
    //     public static string PLAYER_ON_TURN_END = "PLAYER_ON_TURN_END";
    // }

    // public class GameEventPriority
    // {
    //     public class GameStart
    //     {
    //         public static int DEFAULT = 0;
    //         public static int DRAW_CARD = 50;   // 抽牌
    //         public static int ACTION = 100;     // 外部传递的默认回调
    //         public static int UI = 1000;  // 刷新，比较靠后
    //         public static int PHASE_CHANGE = 2000;    // 阶段转换，这个肯定是最后
    //     }

    //     public class TurnBegin
    //     {
    //         public static int DEFAULT = 0;
    //         public static int ACTION = 100;     // 外部传递的默认回调
    //         public static int UI = 1000;  // 刷新，比较靠后
    //         public static int PHASE_CHANGE = 2000;    // 阶段转换，这个肯定是最后
    //     }
    // }
}
