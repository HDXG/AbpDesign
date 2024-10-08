﻿namespace DesignSetup.Application.Serilogs.Dtos
{
    public class SerilogDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? HttpMethod { get; set; }
        public int HttpStatusCode { get; set; }
        public string? TotalMilliseconds { get; set; }
    }
}
