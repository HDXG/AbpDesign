using Design.Application;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application
{
    public class DesignSetupApplicationAutoMapperProfile : DesignApplicationAutoMapperProfile
    {
        public DesignSetupApplicationAutoMapperProfile()
        {
            CreateMap<SysUser, SysUserDto>().ReverseMap();
            CreateMap<SysMenuPermissions, SysMenuPermissionsDto>().ReverseMap();
        }
    }
}
