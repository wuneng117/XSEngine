namespace XSEngine
{
    /// <summary>
    /// 技能倒计时用的类
    /// </summary>
    public class CountDown
    {
        public int Time { get; set; } = 0;
        public bool Active { get; protected set; } = false;
        public bool Finish { get; protected set; } = false;
        protected int UpdateTurn { get; set; } = 0;

        /// <summary>
        /// 倒计时开始
        /// </summary>
        /// <param name="time">几回合倒计时</param>
        public void Start(int time)
        {
            this.Time = time;
            this.Active = true;
            this.UpdateTurn = 0;
            this.Finish = this.UpdateTurn >= this.Time;
        }

        /// <summary>
        /// 倒计时停止
        /// </summary>
        public void Stop()
        {
            this.Active = false;
            this.UpdateTurn = 0;
            this.Finish = false;
        }

        /// <summary>
        /// update要手动调用
        /// </summary>
        /// <param name="turnCount">更新几回合</param>
        public void Update(int turnCount = 1)
        {
            if (this.Active == false)
                return;

            this.UpdateTurn += turnCount;
            this.Finish = this.UpdateTurn >= this.Time;
        }
    }
}