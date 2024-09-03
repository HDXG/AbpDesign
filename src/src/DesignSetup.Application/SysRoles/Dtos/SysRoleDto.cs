using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts;

namespace DesignSetup.Application.SysRoles.Dtos
{
    public class SysRoleDto:HasCreateDeleteEntityDto<Guid>
    {
        public string RoleName { get; set; }
        public string Note { get; set; }
        public string IsDefault { get; set; }
        public string IsStatus { get; set; }
    }
}
