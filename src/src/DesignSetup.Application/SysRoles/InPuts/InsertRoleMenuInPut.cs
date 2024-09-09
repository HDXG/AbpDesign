using Design.Application.Contracts.Extensions;

namespace DesignSetup.Application.SysRoles.InPuts
{
    public class InsertRoleMenuInPut:GetDto 
    {
        public List<Guid> menuList { get; set; }
    }
}
