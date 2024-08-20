using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application;
using DesignSetup.Application.Users.Dtos;
using DesignSetup.Domain.Users;

namespace DesignSetup.Application
{
    public class DesignSetupApplicationAutoMapperProfile : DesignApplicationAutoMapperProfile
    {
        public DesignSetupApplicationAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
