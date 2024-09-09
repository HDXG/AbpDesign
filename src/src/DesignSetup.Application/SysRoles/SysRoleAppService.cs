using AutoMapper;
using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysMenuPermissiones.OutPuts;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Application.SysRoles.InPuts;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysRoleMenus;
using DesignSetup.Domain.SysRoles;
using Volo.Abp.Domain.Repositories;

namespace DesignSetup.Application.SysRoles
{
    public interface ISysRoleAppService
    {
        /// <summary>
        /// 返回角色列表内容
        /// </summary>
        /// <returns></returns>
        Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync(GetPageRoleDto t);

        Task<bool> InsertRoleAsync(SysRoleDto t);

        Task<bool> UpdateRoleAsync(SysRoleDto t);

        Task<SysRoleDto> GetRoleAsync(GetDto Id);

        Task<bool> DeletePageAsync(GetDto t);

        Task<List<RoleListDto>> RoleList();

        /// <summary>
        /// 添加角色的对应菜单内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> InsertRoleMenuAsync(InsertRoleMenuInPut t);

        /// <summary>
        /// 角色管理 分配菜单权限使用
        /// </summary>
        /// <returns></returns>
        Task<TreePermissionsOutPut> TreePermissionsAsync(GetDto d);

    }
    public class SysRoleAppService(ISysRoleRepository _roleRepository,
        ISysRoleMenuRepository _romeMenu,
        ISysMenuPermissionsRepository _sysMenuRepository) : DesignApplicationService, ISysRoleAppService
    {
        public async Task<bool> DeletePageAsync(GetDto t)
        {
            await _roleRepository.DeleteAsync(x => x.Id == t.Id);
            return true;
        }

        public async Task<SysRoleDto> GetRoleAsync(GetDto t) => ObjectMapper.Map<SysRole,SysRoleDto>(await _roleRepository.GetAsync(x => x.Id == t.Id));

        public async Task<bool> InsertRoleAsync(SysRoleDto t) =>await _roleRepository.InsertAsync(ObjectMapper.Map<SysRoleDto, SysRole>(t)) != null;

        public async Task<bool> InsertRoleMenuAsync(InsertRoleMenuInPut t)
        {
            await _romeMenu.DeleteManyAsync(await _romeMenu.GetListAsync(x=>x.RoleId==t.Id));
            List<SysRoleMenu> list = new List<SysRoleMenu>();
            foreach (var item in t.menuList)
            {
                list.Add(new SysRoleMenu(GuidGenerator.Create())
                {
                    RoleId=t.Id,
                    MenuId=item,
                    IsDelete=true,
                    CreateTime=DateTime.Now
                });
            }
            await _romeMenu.InsertManyAsync(list,true);
            return true;
        }

        public async Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync(GetPageRoleDto t)
        {
            var data = await _roleRepository.GetPagedListAsync(x=>x.RoleName.EndsWith(t.RoleName) && x.IsDelete,x=>x.Order,false,t.PageIndex,t.PageSize
                );
            return new PagedResultOutPut<SysRoleDto>(data.Item1,ObjectMapper.Map<List<SysRole>,List<SysRoleDto>>(data.Item2));
        }

        public async Task<List<RoleListDto>> RoleList() =>
            ObjectMapper.Map<List<SysRole>, List<RoleListDto>>(await _roleRepository.GetListAsync(x => x.IsStatus));

        public async Task<bool> UpdateRoleAsync(SysRoleDto t) => await _roleRepository.UpdateAsync(ObjectMapper.Map<SysRoleDto,SysRole>(t)) != null;


        public async Task<TreePermissionsOutPut> TreePermissionsAsync(GetDto t)
        {
            List<SysRoleMenu> roleMenu = await _romeMenu.GetListAsync(x => x.RoleId == t.Id);

            //获取当前角色的权限
            List<TreePermissions> treePermissions = new List<TreePermissions>();
            List<SysMenuPermissions> sysMenus = await _sysMenuRepository.GetListAsync(x => x.IsDelete && x.IsStatus);
            foreach (var item in sysMenus.Where(x => x.Fatherid == Guid.Empty))
            {
                treePermissions.Add(new TreePermissions()
                {
                    id = item.Id,
                    label = item.MenuName,
                    children = RecursionTreePermissions(sysMenus, item.Id)
                });
            }
            return new TreePermissionsOutPut()
            {
                menuTreeList = treePermissions,
                roleMenIdList= roleMenu.Select(x=>x.MenuId).ToList()
            };
        }

        private List<TreePermissions> RecursionTreePermissions(List<SysMenuPermissions> sysMenus, Guid faterId)
        {
            List<TreePermissions> tree = new List<TreePermissions>();
            foreach (var item in sysMenus.Where(x => x.Fatherid == faterId))
            {
                tree.Add(new TreePermissions()
                {
                    label = item.MenuName,
                    id = item.Id,
                    children = RecursionTreePermissions(sysMenus, item.Id)
                });
            }
            return tree;
        }
    }
}
