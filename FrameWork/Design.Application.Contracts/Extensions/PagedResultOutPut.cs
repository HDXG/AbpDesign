namespace Design.Application.Contracts.Services
{
    public class PagedResultOutPut<T>
    {
        public long TotalCount { get; set;}

        public List<T> Item { get; set; }

        public PagedResultOutPut(long totalCount, List<T> items)
        {
            TotalCount = totalCount;
            Item = items;
        }
    }
}
