using System.Collections.Generic;
using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysMenuPermissiones.OutPuts;
using DesignSetup.Domain.SysMenuPermissiones;

namespace DesignSetup.Application.SysMenuPermissiones
{
    public interface ISysMenuPermissionsAppService
    {
        /// <summary>
        /// 分页返回菜单列表
        /// </summary>
        /// <returns></returns>
        Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync();

        /// <summary>
        /// 添加菜单/按钮
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> InsertMenuAsync(SysMenuPermissionsDto t);

        /// <summary>
        /// 修改菜单/按钮
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> UpdateMenuAsync(SysMenuPermissionsDto t);

        /// <summary>
        /// 查单单个菜单/按钮
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<SysMenuPermissionsDto> GetMenuAsync(GetDto t);

        /// <summary>
        /// 返回提供选择的父级菜单等内容
        /// </summary>
        /// <returns></returns>
        Task<List<TreeSelectOutPut>> TreeSelectAsync();

        /// <summary>
        /// 角色管理 分配菜单权限使用
        /// </summary>
        /// <returns></returns>
        Task<List<TreePermissionsOutPut>> TreePermissionsAsync();

       

    }
    public class SysMenuPermissionsAppService(ISysMenuPermissionsRepository _sysMenuRepository) : DesignApplicationService, ISysMenuPermissionsAppService
    {
        public async Task<SysMenuPermissionsDto> GetMenuAsync(GetDto t)=>ObjectMapper.Map<SysMenuPermissions, SysMenuPermissionsDto>(await _sysMenuRepository.GetAsync(x=>x.Id==t.Id));

        public async Task<bool> InsertMenuAsync(SysMenuPermissionsDto t) => await _sysMenuRepository.InsertAsync(ObjectMapper.Map<SysMenuPermissionsDto, SysMenuPermissions>(t)) != null;

        public async Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync()
        {
            var data = await _sysMenuRepository.GetPagedListAsync(x => x.MenuName.StartsWith(""), a => a.CreateTime);
            List<SysMenuPermissionsDto> list = ObjectMapper.Map<List<SysMenuPermissions>, List<SysMenuPermissionsDto>>(data.Item2);
            return new PagedResultOutPut<SysMenuPermissionsDto>(data.Item1, list);
        }


        public async Task<bool> UpdateMenuAsync(SysMenuPermissionsDto t) => await _sysMenuRepository.UpdateAsync(ObjectMapper.Map<SysMenuPermissionsDto, SysMenuPermissions>(t)) != null;

        public async Task<List<TreeSelectOutPut>> TreeSelectAsync()
        {
            List<TreeSelectOutPut> treeSelectOuts = new List<TreeSelectOutPut>();
            List<SysMenuPermissions> sysMenus = await _sysMenuRepository.GetListAsync(x => x.IsDelete && x.IsStatus && x.MenuType!=2);
            treeSelectOuts.Add(new TreeSelectOutPut() { 
                label="顶级菜单",
                value= Guid.Empty,
                children= RecursionMenu(sysMenus,Guid.Empty)
            });
            return treeSelectOuts;
        }

        private List<TreeSelectOutPut> RecursionMenu(List<SysMenuPermissions> sysMenus,Guid faterId)
        {
            List<TreeSelectOutPut> tree = new List<TreeSelectOutPut>();
            foreach (var item in sysMenus.Where(x => x.Fatherid == faterId))
            {
                tree.Add(new TreeSelectOutPut()
                {
                    label = item.MenuName,
                    value = item.Id,
                    children = RecursionMenu(sysMenus,item.Id)
                });
            }
            return tree;
        }

        public async Task<List<TreePermissionsOutPut>> TreePermissionsAsync()
        {
            List<TreePermissionsOutPut> treePermissions = new List<TreePermissionsOutPut>();
            List<SysMenuPermissions> sysMenus = await _sysMenuRepository.GetListAsync(x => x.IsDelete && x.IsStatus);
            foreach (var item in sysMenus.Where(x=>x.Fatherid==Guid.Empty))
            {
                treePermissions.Add(new TreePermissionsOutPut()
                {
                    id = item.Id,
                    label = item.MenuName,
                    children = RecursionTreePermissions(sysMenus,item.Id)
                });
            }
            return treePermissions;
        }

        private List<TreePermissionsOutPut> RecursionTreePermissions(List<SysMenuPermissions> sysMenus,Guid faterId)
        {
            List<TreePermissionsOutPut> tree = new List<TreePermissionsOutPut>();
            foreach (var item in sysMenus.Where(x => x.Fatherid == faterId))
            {
                tree.Add(new TreePermissionsOutPut()
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
