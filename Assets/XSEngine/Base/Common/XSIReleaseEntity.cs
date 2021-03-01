namespace XSEngine.Base
{
    /// <summary>
    /// TriggerBase持有的释放实体
    /// </summary>
    public interface XSIReleaseEntity
    {
        /// <summary>
        /// 是否能释放
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool CanRelease(XSReleaseData data);

        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="data"></param>
        bool Release(XSReleaseData data);

        /// <summary> 保留的玩家对象 </summary>
        XSPlayer Player { get; }
    }
}
