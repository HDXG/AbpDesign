using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts.Services;

namespace DesignSetup.Application.SysRoles.Dtos
{
    public class GetPageRoleDto: PagingBase
    {
        public string? RoleName { get; set; }
    }
}
