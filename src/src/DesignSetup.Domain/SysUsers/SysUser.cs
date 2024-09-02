using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain;
using Volo.Abp.Domain.Entities;

namespace DesignSetup.Domain.SysUsers
{
    public class SysUser : HasCreateDeleteEntity<Guid>
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public bool IsStatus { get; set; }
    }
}
