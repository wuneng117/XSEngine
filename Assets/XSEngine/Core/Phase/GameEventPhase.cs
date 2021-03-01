namespace XSEngine.Core
{
    namespace GameEventPhase
    {
        public enum Event
        {
            ON_ENTER,
            ON_UPDATE,
            ON_EXIT,
        }

        namespace Priority
        {
            public class Base
            {
                public static int DEFAULT = 0;
                public static int BATTLE_EMIT = 500;        // XSBattleEmitter触发phase
                public static int UI = 1000;                // 刷新，比较靠后
                public static int PHASE_CHANGE = 2000;      // 阶段转换，这个肯定是最后
            }
            public class GameStart : Base
            {
                public static int PLAYERMGR_ON_GAME_START = 400;    // playermgr调用ongamestart
            }

            public class GameEnd : Base
            {
            }

            public class TurnBegin : Base
            {
                public static int CURPLAYER_ON_TURN_BEGIN = 400;    // curplayer调用onturnbegin
            }
            public class TurnEnd : Base
            {
                public static int CURPLAYER_ON_TURN_END = 400;    // curplayer调用onturnend
            }
        }
    }
}