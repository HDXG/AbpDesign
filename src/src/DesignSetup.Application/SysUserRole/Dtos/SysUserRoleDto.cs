using Design.Application.Contracts;

namespace DesignSetup.Application.SysUserRoles.Dtos
{
    public class SysUserRoleDto : HasCreateDeleteEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
