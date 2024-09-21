using Design.Application.Contracts.Extensions;
using Design.Application.Services;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysMenuPermissiones.InPuts;
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
        Task<PopedTableOutPut> PagedResultAsync(PagedResultInPut t);

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
        /// 删除菜单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> DeleteMenuAsync(GetDto t);

    }
    public class SysMenuPermissionsAppService(ISysMenuPermissionsRepository _sysMenuRepository) : DesignApplicationService, ISysMenuPermissionsAppService
    {
        public async Task<SysMenuPermissionsDto> GetMenuAsync(GetDto t)=>ObjectMapper.Map<SysMenuPermissions, SysMenuPermissionsDto>(await _sysMenuRepository.GetAsync(x=>x.Id==t.Id));

        public async Task<bool> InsertMenuAsync(SysMenuPermissionsDto t) => await _sysMenuRepository.InsertAsync(ObjectMapper.Map<SysMenuPermissionsDto, SysMenuPermissions>(t)) != null;

        public async Task<bool> DeleteMenuAsync(GetDto t)
        {
            await _sysMenuRepository.DeleteAsync(x => x.Id == t.Id);
            return true;
        }

        public async Task<bool> UpdateMenuAsync(SysMenuPermissionsDto t) => await _sysMenuRepository.UpdateAsync(ObjectMapper.Map<SysMenuPermissionsDto, SysMenuPermissions>(t)) != null;

        #region 选择菜单递归
        public async Task<List<TreeSelectOutPut>> TreeSelectAsync()
        {
            List<TreeSelectOutPut> treeSelectOuts = new List<TreeSelectOutPut>();
            List<SysMenuPermissions> sysMenus = await _sysMenuRepository.GetListAsync(x => x.IsDelete && x.IsStatus && x.MenuType != 2);
            treeSelectOuts.Add(new TreeSelectOutPut()
            {
                label = "顶级菜单",
                value = Guid.Empty,
                children = RecursionMenu(sysMenus, Guid.Empty)
            });
            return treeSelectOuts;
        }

        private List<TreeSelectOutPut> RecursionMenu(List<SysMenuPermissions> sysMenus, Guid faterId)
        {
            List<TreeSelectOutPut> tree = new List<TreeSelectOutPut>();
            foreach (var item in sysMenus.Where(x => x.Fatherid == faterId))
            {
                tree.Add(new TreeSelectOutPut()
                {
                    label = item.MenuName,
                    value = item.Id,
                    children = RecursionMenu(sysMenus, item.Id)
                });
            }
            return tree;
        }
        #endregion

        #region 菜单表格加载递归
        public async Task<PopedTableOutPut> PagedResultAsync(PagedResultInPut t)
        {
            PopedTableOutPut popedTableOutPut = new PopedTableOutPut();
            List<PopedTableChilderOutPut> popedTables = new List<PopedTableChilderOutPut>();
            var list = await _sysMenuRepository.GetListAsync(x =>x.IsDelete);
            int SerialNumber = 1;
            foreach (var item in list.Where(x => x.Fatherid==Guid.Empty).OrderBy(x => x.Order))
            {
                PopedTableChilderOutPut popedTableChilderOutPut = ObjectMapper.Map<SysMenuPermissions, PopedTableChilderOutPut>(item);
                SerialNumber++;
                popedTableChilderOutPut.children = childerMenu(list, item.Id);
                popedTables.Add(popedTableChilderOutPut);
            }
            popedTableOutPut.TotalCount = popedTables.Count;
            popedTableOutPut.Items = popedTables.Skip((t.PageIndex - 1) * t.PageSize).Take(t.PageSize).ToList();
            return popedTableOutPut;
        }

        private List<PopedTableChilderOutPut> childerMenu(List<SysMenuPermissions> list, Guid Id)
        {
            List<PopedTableChilderOutPut> popedTreeOutPuts = new List<PopedTableChilderOutPut>();
            int SerialNumber = 1;
            foreach (var item in list.Where(x => x.Fatherid == Id).OrderBy(x=>x.Order))
            {
                PopedTableChilderOutPut popedTableChilderOutPut = ObjectMapper.Map<SysMenuPermissions, PopedTableChilderOutPut>(item);
                popedTableChilderOutPut.children = childerMenu(list, item.Id);
                popedTableChilderOutPut.SerialNumber = SerialNumber;
                SerialNumber++;
                popedTreeOutPuts.Add(popedTableChilderOutPut);
            }
            return popedTreeOutPuts;
        }
        #endregion

    }
}
