using System.Collections.Generic;

namespace XSEngine.Base
{
    /// <summary>
    /// 技能，就是卡牌的效果
    /// </summary>
    public abstract class XSSkillBase : XSDataBase, XSIReleaseEntity
    {
        /************************* 变量 begin ***********************/

        /// <summary> 触发器 </summary>
        public XSTriggerBase Trigger { get; protected set; }

        /// <summary> 属性值，给具体技能效果使用的数值 </summary>
        protected List<float> PropArray { get; set; } = new List<float>();

        /// <summary> 是否效果被其他技能抵消了 </summary>
        protected bool InvalidByOthers { get; set; } = false;

        /// <summary> 保留的玩家对象 </summary>
        public XSPlayer Player { get; protected set; }
        
        /************************* 变量  end  ***********************/

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">技能id</param>
        /// <param name="name">技能名字</param>
        /// <returns></returns>
        public virtual bool Init(int id, string name, XSPlayer player)
        {
            this.InitData(id, name);
            this.Player = player;
            return true;
        }

        /// <summary>
        /// 开始启动触发器，一般是卡牌存在场上才能发动
        /// </summary>
        public virtual void StartTick() => this.Trigger.StartTick();

        /// <summary>
        ///结束触发器，一般是卡牌离开场上结束
        /// </summary>
        public virtual void StopTick() => this.Trigger.StopTick();

        /// <summary>
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract bool CanRelease(XSReleaseData data);

        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="data"></param>
        public virtual bool Release(XSReleaseData data)
        {
            this.InvalidByOthers = false;
            data.Chain.Add(this);   // 很牛逼的一个链条
            return true;
        }
    }

    /// <summary>
    /// 默认的技能，给CardBase.MainSkill使用，这样就不用去判断是否为null了
    /// </summary>
    public class XSSkillNull : XSSkillBase
    {
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool CanRelease(XSReleaseData data) => true;

        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="data"></param>
        public override bool Release(XSReleaseData data) => true;
    }
}