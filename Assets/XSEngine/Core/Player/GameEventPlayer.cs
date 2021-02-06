namespace XSEngine.Core
{
    namespace GameEventPlayer
    {
        public class Event : GameEvent.Event
        {
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
        }
    }
}