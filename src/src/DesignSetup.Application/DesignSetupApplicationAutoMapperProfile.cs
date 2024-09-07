using Design.Application;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysRoleMenus.Dtos;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Application.SysUserRoles.Dtos;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysRoleMenus;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application
{
    public class DesignSetupApplicationAutoMapperProfile : DesignApplicationAutoMapperProfile
    {
        public DesignSetupApplicationAutoMapperProfile()
        {
           
            CreateMap<SysMenuPermissions, SysMenuPermissionsDto>().ReverseMap();
            CreateMap<SysRoleMenu, SysRoleMenuDto>().ReverseMap();
            CreateMap<SysUserRole, SysUserRoleDto>().ReverseMap();
            CreateMap<SysRole, SysRoleDto>().ReverseMap();
            CreateMap<SysRole, RoleListDto>().ReverseMap();
            CreateMap<SysUser, SysUserDto>().ReverseMap();
        }
    }
}
