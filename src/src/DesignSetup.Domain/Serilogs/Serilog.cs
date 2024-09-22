using Volo.Abp.Domain.Entities;

namespace DesignSetup.Domain.Serilogs
{
    public class Serilog:Entity<int>
    {
        public DateTime TimeStamp { get; set; }
        public string? Url { get; set; }
        public string? HttpMethod { get; set; }
        public string? RequestJson { get; set; }
        public int? HttpStatusCode { get; set; }
        public string? ResponseJson { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? TotalMilliseconds { get; set; }
    }
}
