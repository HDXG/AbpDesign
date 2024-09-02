using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Design.Application.Contracts
{
    public class HasCreateDeleteEntityDto<TKey> : EntityDto<TKey>
    {
        [Description("是否删除")]
        public virtual bool IsDelete { get; set; } = true;
        [Description("添加时间")]
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
