namespace XSEngine.Core
{
    /// <summary> ui刷新事件的参数类型 </summary>
    public class CoreUIEmitterData
    {
        /// <summary> 发出事件的玩家index </summary>
        public int PlayerIndex { get; set; }
    }

    /// <summary> ui刷新事件 </summary>
    public class CoreUIEmitter : Emitter<string, CoreUIEmitterData, bool>
    {
        private static CoreUIEmitter msInstance;
		public static CoreUIEmitter Instance 
        { 
            get => msInstance = msInstance ?? CoreFactory.CreateUIEmitter(); 
        }

        /************************* 阶段事件 begin ***********************/
        public static string UI_PLAYER_GAMESTART = "UI_PLAYER_GAMESTART";
        public static string UI_PLAYER_GAMEEND = "UI_PLAYER_GAMEEND";
        public static string UI_PLAYER_TURNBEGIN = "UI_PLAYER_TURNBEGIN";
        public static string UI_PLAYER_TURNEND = "UI_PLAYER_TURNEND";
        /************************* 阶段事件  end  ***********************/

        /************************* 牌变动 begin ***********************/
        public static string UI_DECK_CHANGED = "UI_DECK_CHANGED";
        public static string UI_PUBLICDECK_CHANGED = "UI_PUBLICDECK_CHANGED";
        public static string UI_HANDCARDS_CHANGED = "UI_HANDCARDS_CHANGED";
        public static string UI_PLAYAREACARDS_CHANGED = "UI_PLAYAREACARDS_CHANGED";
        public static string UI_DISCARDS_CHANGED = "UI_DISCARDS_CHANGED";
        /************************* 牌变动  end  ***********************/
    }
}
