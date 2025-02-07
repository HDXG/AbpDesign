namespace DesignSetup.Infrastructure.RabbitMQHelper
{
    public class CacheUpdateMessage
    {
        public string CacheKey { get; set; } // 缓存的键
        public string Operation { get; set; } // 操作类型，如 "update" 或 "delete"
        public string Data { get; set; } // 数据（可选）
    }

}
