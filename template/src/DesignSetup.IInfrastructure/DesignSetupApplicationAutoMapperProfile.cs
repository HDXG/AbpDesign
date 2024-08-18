using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Design.Application;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.Users.Dtos;

namespace DesignSetup.Infrastructure
{
    public class DesignSetupApplicationAutoMapperProfile: DesignApplicationAutoMapperProfile
    {
        public DesignSetupApplicationAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
