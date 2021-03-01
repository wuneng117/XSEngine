namespace XSEngine.Core
{
    namespace GameEventPlayer
    {
        public enum Event
        {
           ON_GAME_START,
           ON_GAME_END,
           ON_TURN_BEGIN,
           ON_TURN_END,

           USE_CARD,
        }
        public enum CardEvent
        {
           USE_CARD,
        }

        namespace Priority
        {
            public class Base
            {
                public static int DEFAULT = 0;
                public static int ACTION = 100;             // 外部传递的默认回调
                public static int UI = 1000;                // 刷新，比较靠后
            }

            public class GameStart : Base
            {
                public static int DRAW_CARD = 50;           // 抽牌
            }

            public class GameEnd : Base
            {
            }

            public class TurnBegin : Base
            {
                public static int DRAW_CARD = 50;           // 抽牌
            }

            public class TurnEnd : Base
            {
            }

            public class UseCard : Base
            {
                public static int PUT_CARD_FROM_HAND_TO_PLAYAREA = 600; // 牌从手牌出到场上
                public static int TURN_TRIGGER_USE_CARD = 800;  // turntrigger调用usecard
            }
        }
    }
}