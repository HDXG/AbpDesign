using System.ComponentModel;
using Design.Domain;

namespace DesignSetup.Domain.SysRoleMenus
{
    /// <summary>
    /// 角色 菜单/权限
    /// </summary>
    public class SysRoleMenu:HasCreateDeleteEntity<Guid>
    {
        [Description("角色Id")]
        public Guid RoleId {  get; set; }

        [Description("菜单/权限Id")]
        public Guid MenuId { get; set; }
    }
}
