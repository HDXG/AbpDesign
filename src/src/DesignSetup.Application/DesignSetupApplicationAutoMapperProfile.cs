using Design.Application;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysMenuPermissiones.OutPuts;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application
{
    public class DesignSetupApplicationAutoMapperProfile : DesignApplicationAutoMapperProfile
    {
        public DesignSetupApplicationAutoMapperProfile()
        {
           
            CreateMap<SysMenuPermissions, SysMenuPermissionsDto>().ReverseMap();
            CreateMap<SysRole, SysRoleDto>().ReverseMap();
            CreateMap<SysRole, RoleListDto>().ReverseMap();
            CreateMap<SysUser, SysUserDto>().ReverseMap();
            CreateMap<SysMenuPermissions, PopedTableChilderOutPut>().ReverseMap();
        }
    }
}
