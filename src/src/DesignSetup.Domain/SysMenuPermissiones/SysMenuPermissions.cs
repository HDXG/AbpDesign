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

        [Description("路由名称")]
        public string RouteName { get; set; }

        [Description("路由路径")]
        public string MenuUrl { get; set; }

        [Description("组件路径")]
        public string ComponentPath { get; set; }

        [Description("父级Id")]
        public Guid Fatherid { get; set; }

        [Description("菜单图标")]
        public string Icon { get; set; }

        [Description("0目录 1菜单 2按钮")]
        public int MenuType { get; set; }

        [Description("按钮权限标识")]
        public string Identification { get; set; }

        [Description("是否启用")]
        public bool IsStatus { get; set; }





        public SysMenuPermissions(Guid id) : base(id)
        {

        }

    }
}
