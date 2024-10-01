using Design.Application.Contracts;

namespace DesignSetup.Application.SysUsers.Dtos
{
    public class GetUserListDto: HasCreateDeleteEntityDto<Guid>
    {
        public string? AccountNumber { get; set; }
        public string? UserName { get; set; }

        public string? RoleName { get; set; }

        public bool IsStatus { get; set; } = true;
    }
}
