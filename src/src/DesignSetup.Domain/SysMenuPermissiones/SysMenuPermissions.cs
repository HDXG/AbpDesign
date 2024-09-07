using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain;

namespace DesignSetup.Domain.SysMenuPermissiones
{
    public class SysMenuPermissions:HasCreateDeleteEntity<Guid>
    {
        [Description("菜单/按钮 名称")]
        public string MenuName { get; set; }

        [Description("菜单路径")]
        public string MenuUrl { get; set; }

        [Description("父级Id")]
        public Guid Fatherid { get; set; }

        [Description("菜单图标")]
        public string Icon { get; set; }

        [Description("1菜单 0按钮")]
        public bool MenuType { get; set; }

        [Description("按钮权限标识")]
        public string Identification { get; set; }

        public SysMenuPermissions(Guid id) : base(id)
        {

        }

    }
}
