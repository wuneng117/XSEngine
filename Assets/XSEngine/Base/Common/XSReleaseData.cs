using System.Collections.Generic;

namespace XSEngine.Base
{
    public class XSReleaseData
    {
        public XSPlayer Src { get; }
        public List<XSPlayer> Dst { get; } = new List<XSPlayer>();
        /// <summary> 释放链，用来无效一些技能 </summary>
        public List<XSSkillBase> Chain { get; } = new List<XSSkillBase>();

        public XSReleaseData(XSPlayer src = null, List<XSPlayer> dst = null)
        {
            this.Src = src;
            this.Dst = dst;
        }

        /// <summary>
        /// 多个参数传递
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst">多个参数啊啊啊啊</param>
        public XSReleaseData(XSPlayer src, params XSPlayer[] dst)
        {
            this.Src = src;
            this.Dst = new List<XSPlayer>(dst);
        }
    }

    public class AttackReleaseData : XSReleaseData
    {
        public int damage;

        public AttackReleaseData(XSPlayer src, List<XSPlayer> dst, int damage) : base(src, dst)
        {
            this.damage = damage;
        }
    }
}
