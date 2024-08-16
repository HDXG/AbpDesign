using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace DesignSetup.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public string Account { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
