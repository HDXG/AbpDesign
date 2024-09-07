using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignSetup.Application.SysUsers.Dtos;

namespace DesignSetup.Application.SysUsers.InPuts
{
    public class InsertUserOutPut
    {
        public SysUserDto model { get; set; }

        public List<Guid> guids { get; set; }
    }
}
