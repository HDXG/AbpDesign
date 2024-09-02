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
    }
}
