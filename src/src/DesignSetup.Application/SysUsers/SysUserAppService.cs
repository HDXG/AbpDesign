﻿using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Application.SysUsers.InPuts;
using DesignSetup.Application.SysUsers.OutPuts;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Domain.SysUsers;
using Volo.Abp.Domain.Repositories;

namespace DesignSetup.Application.SysUsers
{
    public interface ISysUserAppService: IDesignApplicationService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> InsertUserAsync(InsertUserOutPut t);
        Task<bool> UpdateUserAsync(InsertUserOutPut t);
        Task<PagedResultOutPut<GetUserListDto>> GetPagedResultAsync(GetUserPageListInPut t);

        Task<bool> DeleteAsync(GetDto t);

        /// <summary>
        /// 根据用户Id返回用户信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<GetUserOutPut> GetUserDto(GetDto t);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<GetLogInOutPut> GetLogIn(LoginUserInPut t);

        /// <summary>
        /// 根据用户Id 直接返回菜单列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<loginUserMenuOutPut>> GetByUserIdMenu(Guid id);
    }
    public class SysUserAppService(ISysUserRepository sysUserRepository,
        ISysRoleRepository roleRepository,
        ISysUserRoleRepository userRoleRepository,
        ISysMenuPermissionsRepository menuPermissionsRepository) : DesignApplicationService, ISysUserAppService
    {
        public async Task<bool> DeleteAsync(GetDto t)
        {
            var SysUser = await sysUserRepository.FirstOrDefaultAsync(x => x.Id == t.Id);
            SysUser.IsDelete = false;
            await sysUserRepository.UpdateAsync(SysUser);
            await userRoleRepository.DeleteManyAsync(await userRoleRepository.GetListAsync(x => x.UserId == t.Id),true);
            return true;
        }

        public async Task<PagedResultOutPut<GetUserListDto>> GetPagedResultAsync(GetUserPageListInPut t)
        {
            var list = await sysUserRepository.GetUserListAsync<GetUserListDto>(t.userName);
            return new PagedResultOutPut<GetUserListDto>(
                list.Count,
                list.Skip((t.PageIndex - 1) * t.PageSize).Take(t.PageSize).ToList());
        }

        public async Task<GetUserOutPut> GetUserDto(GetDto t)
        {
            var rolelist = await userRoleRepository.GetListAsync(x => x.UserId == t.Id);
            return new GetUserOutPut()
            {
                model = ObjectMapper.Map<SysUser, SysUserDto>(await sysUserRepository.GetAsync(x => x.Id == t.Id)),
                roleIds= rolelist.Select(x => x.RoleId).ToList()
            };
        }

        public async Task<bool> InsertUserAsync(InsertUserOutPut t)
        {

            bool flag= await sysUserRepository.InsertAsync(ObjectMapper.Map<SysUserDto, SysUser>(t.model)) != null;
            if (flag)
            {
                await InsertUserRole(t);
            }
            return flag;
        }

        private async Task InsertUserRole(InsertUserOutPut t)
        {
            List<SysUserRole> sysUserRoles = new List<SysUserRole>();
            var RoleList = await roleRepository.GetListAsync(x => x.IsDefault && x.IsStatus);

            List<Guid> guids = new List<Guid>();
            t.guids.ForEach(c => { guids.Add(c); });
            RoleList.ForEach(c =>
            {
                if (guids.Count(x => x == c.Id) == 0)
                {
                    guids.Add(c.Id);
                }
            });
            guids.ForEach(c =>
            {
                sysUserRoles.Add(new SysUserRole(GuidGenerator.Create())
                {
                    CreateTime = DateTime.Now,
                    IsDelete = true,
                    RoleId = c,
                    UserId = t.model.Id,
                });
            });
            await userRoleRepository.InsertManyAsync(sysUserRoles, true);
        }

        public async Task<bool> UpdateUserAsync(InsertUserOutPut t)
        {
            bool flag = await sysUserRepository.UpdateAsync(ObjectMapper.Map<SysUserDto, SysUser>(t.model))!=null;
            if (flag)
            {
                await userRoleRepository.DeleteManyAsync(await userRoleRepository.GetListAsync(x=>x.UserId==t.model.Id),true );
                await InsertUserRole(t);
            }
            return flag;
        }

        #region 用户登录

        public async Task<GetLogInOutPut> GetLogIn(LoginUserInPut t)
        {
            GetLogInOutPut getLogIn = new GetLogInOutPut();
            SysUser sysUser =await sysUserRepository.FirstOrDefaultAsync(x => x.AccountNumber == t.AccountNumber && x.PassWord == t.PassWord)??new SysUser(Guid.Empty);
            if (sysUser == null)
                throw new Exception("当前用户不存在");
            if (!sysUser.IsDelete || !sysUser.IsStatus)
                throw new Exception("当前用户不允许登录");

            getLogIn.UserInfo = new GetLogInUserInfoDto(sysUser.UserName,sysUser.Id);
            return getLogIn;
        }

        public async Task<List<loginUserMenuOutPut>> GetByUserIdMenu(Guid id)
        {
            List<loginUserMenuOutPut> menuList = new List<loginUserMenuOutPut>();
            var getUserMenu = await menuPermissionsRepository.GetUserRoleIdMenuList(id);
            foreach (var item in getUserMenu.Where(x => x.Fatherid == Guid.Empty))
            {
                menuList.Add(new loginUserMenuOutPut()
                {
                    title = item.MenuName,
                    ComponentPath = item.ComponentPath,
                    RouteName = item.RouteName,
                    MenuUrl = item.MenuUrl,
                    Icon = item.Icon,
                    children = ChildLoginUserMenuOutPuts(getUserMenu, item.Id)
                });
            }
            return menuList;
        }

        private List<loginUserMenuOutPut> ChildLoginUserMenuOutPuts(List<SysMenuPermissions> list, Guid id)
        {
            List<loginUserMenuOutPut> menuList = new List<loginUserMenuOutPut>();

            foreach (var item in list.Where(x => x.Fatherid ==id))
            {
                menuList.Add(new loginUserMenuOutPut()
                {
                    title = item.MenuName,
                    ComponentPath = item.ComponentPath,
                    RouteName = item.RouteName,
                    MenuUrl = item.MenuUrl,
                    Icon = item.Icon,
                    children = ChildLoginUserMenuOutPuts(list,item.Id)
                });
            }

            return menuList;
        }

        #endregion
    }
}
