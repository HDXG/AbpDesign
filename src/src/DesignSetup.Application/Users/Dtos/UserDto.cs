using Volo.Abp.Application.Dtos;

namespace DesignSetup.Application.Users.Dtos
{
    public class UserDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public string PassWord { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
