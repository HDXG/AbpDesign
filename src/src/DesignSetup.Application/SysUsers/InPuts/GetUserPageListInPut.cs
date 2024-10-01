using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts.Services;

namespace DesignSetup.Application.SysUsers.InPuts
{
    public class GetUserPageListInPut:PagingBase
    {
        public string? userName { get; set; } 
    }
}
