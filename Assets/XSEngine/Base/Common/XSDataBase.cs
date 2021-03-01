namespace XSEngine.Base
{
    public abstract class XSDataBase
    {
        /// <summary> id </summary>
        public int Id { get; protected set; } = 0;

        /// <summary> 名字 </summary>
        public string Name { get; protected set; } = "";

        /// <summary>
        /// 初始化
        /// </summary>
        protected void InitData(int id, string name) => (this.Id, this.Name) = (id, name);
    }
}