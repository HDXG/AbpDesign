using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain.Repositories;

namespace DesignSetup.Domain.SysMenuPermissiones
{
    public interface ISysMenuPermissionsRepository:IDesignRepository<SysMenuPermissions,Guid>
    {
        /// <summary>
        /// 根据用户Id 获取用户的菜单内容
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<List<SysMenuPermissions>> GetUserRoleIdMenuList(Guid Id);

        /// <summary>
        /// 根据用户Id 获取当前用户的 所有按钮权限
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<List<string>> GetUserRoleIdBtnList(Guid Id);
    }
}
