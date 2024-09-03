using System.ComponentModel;
using Design.Domain;

namespace DesignSetup.Domain.SysRoles
{
    public class SysRole:HasCreateDeleteEntity<Guid>
    {
        [Description("角色名称")]
        public string RoleName { get; set; }

        [Description("角色备注")]
        public string Note { get; set; }

        [Description("是否默认角色")]
        public string IsDefault { get; set; }

        [Description("是否启用")]
        public string IsStatus { get; set; }
    }
}
