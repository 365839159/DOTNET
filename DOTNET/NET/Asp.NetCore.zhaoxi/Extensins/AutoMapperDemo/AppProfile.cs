using AutoMapper;
using AutoMapperDTO;
using AutoMapperEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            base.CreateMap<UserInfo,UserInfoDto>();
        }
    }
}
