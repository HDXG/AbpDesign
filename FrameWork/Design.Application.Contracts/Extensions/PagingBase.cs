namespace Design.Application.Contracts.Services
{
    /// <summary>
    /// 分页基类
    /// </summary>
    public class PagingBase
    {
        public const int MaxPageSize = 100000;

        /// <summary>
        /// 当前页面.默认从1开始
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页多少条.每页显示多少记录
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 跳过多少条
        /// </summary>
        public int SkipCount => (PageIndex - 1) * PageSize;

        protected PagingBase()
        {
        }
        public PagingBase(int pageIndex = 1, int pageSize = 10)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
