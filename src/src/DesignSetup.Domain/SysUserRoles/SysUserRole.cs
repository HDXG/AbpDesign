using System.ComponentModel;
using Design.Domain;

namespace DesignSetup.Domain.SysUserRoles
{
    public class SysUserRole:HasCreateDeleteEntity<Guid>
    {
        [Description("用户Id")]
        public Guid UserId { get; set; }

        [Description("角色Id")]
        public Guid RoleId { get; set; }

        public SysUserRole(Guid id): base(id)
        {

        }
    }
}
