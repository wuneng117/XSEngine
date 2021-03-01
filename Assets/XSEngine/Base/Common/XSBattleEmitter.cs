using System;
using GameDataEditor;

namespace XSEngine.Base
{
    /// <summary> 各种效果触发条件的管理 </summary>
    public class XSBattleEmitter : Emitter<TriggerDataTriggerBasicType, Action<XSReleaseData>>
    {
        private static XSBattleEmitter msInstance;
		public static XSBattleEmitter Instance { get => msInstance = msInstance ?? (XSFactory.CreateBattleEmitter()); } 

        // /************************* 阶段事件 begin ***********************/
        // public static string BATTLE_ON_TURN_BEGIN = "BATTLE_ON_TURNBEGIN";
        // public static string BATTLE_ON_TURN_END = "BATTLE_ON_TURNEND";
        // public static string BATTLE_ON_GAME_START = "BATTLE_ON_GAMESTART";
        // public static string BATTLE_ON_GAME_END = "BATTLE_ON_GAMEEND";
        // /************************* 触发事件  end  ***********************/

        // /************************* 攻击事件 begin ***********************/
        // public static string BATTLE_ON_BEFORE_ATTACK = "BATTLE_ON_BEFORE_ENEMY_ATTACK";
        // public static string BATTLE_ON_AFTER_ATTACK = "BATTLE_ON_AFTER_ATTACK";
        // /************************* 攻击事件  end  ***********************/
    }
}
