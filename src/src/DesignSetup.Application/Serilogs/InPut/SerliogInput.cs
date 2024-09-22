using Design.Application.Contracts.Services;

namespace DesignSetup.Application.Serilogs.InPut
{
    public class SerliogInput:PagingBase
    {
        public string HttpMethod { get; set; }
        public string url { get; set; }
    }
}
