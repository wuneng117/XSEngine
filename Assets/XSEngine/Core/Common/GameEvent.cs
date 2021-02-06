namespace XSEngine.Core
{
    namespace GameEvent
    {
        public class Event
        {
            public static string ON_GAME_START = "ON_GAME_START";
            public static string ON_GAME_END = "ON_GAME_END";
            public static string ON_TURN_BEGIN = "ON_TURN_BEGIN";
            public static string ON_TURN_END = "ON_TURN_END";
        }

    //     namespace Priority
    //     {
    //         public class Base
    //         {
    //             public static int DEFAULT = 0;
    //             public static int BATTLE_EMIT = 500;        // XSBattleEmitter触发phase
    //             public static int UI = 1000;                // 刷新，比较靠后
    //             public static int PHASE_CHANGE = 2000;      // 阶段转换，这个肯定是最后
    //         }
    //         public class GameStart : Base
    //         {
    //             public static int PLAYERMGR_ON_GAME_START = 500;    // playermgr调用ongamestart
    //         }

    //         public class GameEnd : Base
    //         {
    //         }

    //         public class TurnBegin : Base
    //         {
    //             public static int CURPLAYER_ON_TURN_BEGIN = 400;    // curplayer调用onturnbegin
    //         }
    //         public class TurnEnd : Base
    //         {
    //             public static int CURPLAYER_ON_TURN_END = 400;    // curplayer调用onturnend
    //         }
    //     }
    }
}