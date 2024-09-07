using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts;
using Design.Domain;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application.SysUsers.Dtos
{
    public class SysUserDto: HasCreateDeleteEntityDto<Guid>
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        public string PassWord { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public bool IsStatus { get; set; } = true;
    }
}
