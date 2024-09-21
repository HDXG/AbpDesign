using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Application.SysUsers.Dtos;

namespace DesignSetup.Application.SysUsers.OutPuts
{
    public class GetUserOutPut
    {
        public SysUserDto model { get; set; }

        public  List<Guid> roleIds { get; set; }
    }
}
