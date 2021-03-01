using System.Diagnostics;
using System;

namespace XSEngine.Base
{
    /// <summary>
    /// 触发器，触发技能释放，或者buff和技能的结束触发
    /// </summary>
    public abstract class XSTriggerBase : XSDataBase
    {
        /************************* 变量 begin ***********************/

        /// <summary> 技能释放，TODO只要一个接口 </summary>
        protected XSIReleaseEntity ReleaseEntity { get; set; }

        /// <summary> 倒计时 </summary>
        protected CountDown Cd { get; set; }

        /************************* 变量  end  ***********************/

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">触发器id</param>
        /// <param name="name">触发器name</param>
        /// <param name="name">触发器触发的对象</param>
        public bool Init(int id, string name, XSIReleaseEntity releaseEntity)
        {
            Debug.Assert(releaseEntity != null);
            this.InitData(id, name);
            this.ReleaseEntity = releaseEntity;
            this.Cd = new CountDown();
            return true;
        }

        /// <summary>
        /// 开始启动触发器，一般是卡牌存在场上才能发动
        /// </summary>
        public abstract void StartTick();

        /// <summary>
        ///结束触发器，一般是卡牌离开场上结束
        /// </summary>
        public abstract void StopTick();

        /// <summary>
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool CanRelease(XSReleaseData data) => this.Cd.Active && this.Cd.Finish && this.ReleaseEntity.CanRelease(data);

        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="data"></param>
        public virtual bool Release(XSReleaseData data) => this.CanRelease(data) ? this.ReleaseEntity.Release(data) : false;

        /// <summary>
        /// 回合开始响应
        /// </summary>
        public virtual void OnTurnStart() => this.CdUpdate();

        /// <summary>
        /// cd更新
        /// </summary>
        protected void CdUpdate()
        {
            if (!this.Cd.Active)
                return;

            int turnCount = 1;
            this.Cd.Update(turnCount);
        }
    }

    /// <summary>
    /// 默认的触发器，不注册任何事件，手动调用触发时肯定可以触发，当技能data没有填触发器id时，技能默认用的这个
    /// </summary>
    public class XSTriggerNull : XSTriggerBase
    {
        /// <summary>
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool CanRelease(XSReleaseData data) => true;

        /// <summary>
        /// 开始工作
        /// </summary>
        public override void StartTick() { }
        /// <summary>
        ///结束触发器，一般是卡牌离开场上结束
        /// </summary>
        public override void StopTick() { }
    }
}