using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts;

namespace DesignSetup.Application.SysRoleMenus.Dtos
{
    public class SysRoleMenuDto:HasCreateDeleteEntityDto<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
    }
}
