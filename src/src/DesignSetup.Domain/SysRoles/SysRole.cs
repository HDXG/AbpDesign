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
        public bool IsDefault { get; set; }

        [Description("角色状态")]
        public bool IsStatus { get; set; }

        [Description("显示顺序")]
        public int Order { get; set; }

        public SysRole(Guid id) : base(id)
        {

        }
    }
}
