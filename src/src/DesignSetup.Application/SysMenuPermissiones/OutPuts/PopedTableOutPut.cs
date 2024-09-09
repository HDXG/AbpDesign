using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignSetup.Application.SysMenuPermissiones.Dtos;

namespace DesignSetup.Application.SysMenuPermissiones.OutPuts
{
    public class PopedTableOutPut
    {
        public long TotalCount { get; set; }
        public List<PopedTableChilderOutPut> Items { get; set; }
    }
    public class PopedTableChilderOutPut : SysMenuPermissionsDto
    {
        public int SerialNumber { get; set; }
        public List<PopedTableChilderOutPut> children { get; set; }
    }
}
