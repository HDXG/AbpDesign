using Design.Application.Contracts.Services;

namespace DesignSetup.Application.Serilogs.InPut
{
    public class SerilogInPut:PagingBase
    {
        public string? HttpMethod { get; set; }
        public string? url { get; set; }
    }
}
