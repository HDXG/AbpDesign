using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts;

namespace DesignSetup.Application.SysMenuPermissiones.Dtos
{
    public class SysMenuPermissionsDto:HasCreateDeleteEntityDto<Guid>
    {
        public string MenuName { get; set; }
        public string RouteName { get; set; }
        public string MenuUrl { get; set; }
        public string ComponentPath { get; set; }
        public Guid Fatherid { get; set; }
        public string Icon { get; set; }
        public int MenuType { get; set; }
        public string Identification { get; set; }

        public bool IsStatus { get; set; }
    }
}
