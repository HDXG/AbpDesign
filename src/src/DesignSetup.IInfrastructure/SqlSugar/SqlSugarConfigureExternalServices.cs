using System.Reflection;
using DesignSetup.Domain.SysRoleMenus;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUsers;
using SqlSugar;

namespace DesignSetup.Infrastructure.SqlSugar
{
    public static class SqlSugarConfigureExternalServices
    {
        public static ConfigureExternalServices Get()
        {
            Action<PropertyInfo, EntityColumnInfo> EntityServiceAction = (s, p) =>
            {
                // 是id的设为主键
                if (p.PropertyName.ToLower() == "id")
                {
                    p.IsPrimarykey = true;
                }
            };

            Action<Type, EntityInfo> EntityNameServiceAction = (type, entity) =>
            {
                if (type.Name == nameof(SysRole))
                {
                    entity.DbTableName = "SysRole";
                }
                else if (type.Name == nameof(SysUser))
                {
                    entity.DbTableName = "SysUser";
                }
            };


            return new ConfigureExternalServices()
            {
                EntityService = EntityServiceAction,
                EntityNameService = EntityNameServiceAction
            };
        }
    }
}
