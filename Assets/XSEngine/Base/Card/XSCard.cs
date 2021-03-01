using System.Collections.Generic;
using XSEngine.Core;

namespace XSEngine.Base
{
    public interface XSICardBase
    {
        void Use();
    }

    /// <summary>
    /// 卡牌，就是代表了卡牌桌游里的一张牌
    /// </summary>
    public class XSCard : CoreCardBase, XSICardBase
    {
        protected XSSkillBase MainSkill { get; set; }
        protected List<XSSkillBase> SkillArray { get; set; } = new List<XSSkillBase>();

        public virtual void Use()
        {
            this.SkillArray.ForEach(skill => skill.StartTick());
        }
    }
}