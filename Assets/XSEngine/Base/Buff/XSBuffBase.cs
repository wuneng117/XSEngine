using System.Collections.Generic;
namespace XSEngine.Base
{
    /// <summary>
    /// 可以添加刪除的buff，通常由技能附加
    /// </summary>
    public abstract class XSBuffBase : XSDataBase, XSIReleaseEntity
    {
        /************************* 变量 begin ***********************/

        /// <summary> 触发器 </summary>
        public XSTriggerBase Trigger { get; protected set; }

        /// <summary> 结束触发器 </summary>
        public XSTriggerBase FinishTrigger { get; protected set; }

        /// <summary> buff对属性的影响 </summary>
        protected List<XSStatBase> StatArray {get; set; } = new List<XSStatBase>();

        /// <summary> 保留的玩家对象 TODO 需要赋值 </summary>
        public XSPlayer Player { get; protected set; }
        
        /************************* 变量  end  ***********************/
        
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual bool Init(int id, string name, XSPlayer player)
        {
            this.InitData(id, name);
            this.Player = player;
            return true;
        }        
        
        /// <summary>
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool CanRelease(XSReleaseData data) => true;

        /// <summary>
        /// 释放buff效果
        /// </summary>
        /// <param name="data"></param>
        public abstract bool Release(XSReleaseData data);

        /// <summary>
        /// 结束buff
        /// </summary>
        /// <param name="data"></param>
        public abstract bool Died(XSReleaseData data);
    }
}
