using System;

namespace XSEngine.Core
{
    /// <summary> GameEvent </summary>
    public class CoreGameEventEmitter : Emitter<string, Action>
    {
        private static CoreGameEventEmitter msInstance;
        public static CoreGameEventEmitter Instance { get => msInstance = msInstance ?? CoreFactory.CreateGameEventEmitter(); }
    }
}
