using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapperDTO;
using AutoMapperEntity;

namespace AutoMapperDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = new UserInfo() { Id = 1, Adress = "北京", Age = 18, Name = "zxc" };
            {
                //硬编码
                var userInfodto = new UserInfoDto
                { 
                    Id = userInfo.Id, 
                    Adress = userInfo.Adress, 
                    Age = userInfo.Age, 
                    Name = userInfo.Name 
                };
            }

            {
                //AutoMapper使用1

                //创建配置
                var configure = new MapperConfiguration(option => { option.CreateMap<UserInfo, UserInfoDto>(); });
                //创建实例
                var mapper = configure.CreateMapper();

                //or
                //var  mapper = new Mapper(configure);

                //使用
                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
            }

            {
                //AutoMapper使用2
                var configurationException = new MapperConfigurationExpression();
                configurationException.CreateMap<UserInfo, UserInfoDto>();

                var config = new MapperConfiguration(configurationException);
                var mapper = config.CreateMapper();

                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
            }

            {
                //AutoMapper 使用3
                var config = new MapperConfiguration(config => { config.AddProfile(new AppProfile()); });

                var mapper = config.CreateMapper();

                var userInfoDto = mapper.Map<UserInfoDto>(userInfo);
            }

            #region 投影
            {
                var config = new MapperConfiguration(config => { config.AddProfile(new AppProfile()); });

                var mapper = config.CreateMapper();

                var query = new List<UserInfo>() {
                    new UserInfo { Id = 1, Age = 18, Name = "zxc", Adress = "北京" },
                    new UserInfo { Id = 2, Age = 18, Name = "zxc", Adress = "北京" },
                    new UserInfo { Id = 3, Age = 18, Name = "zxc", Adress = "北京" },
                }.AsQueryable();

                //var userInfoDtoList = mapper.ProjectTo<UserInfoDto>(query);

                //自己定义的扩展方法
                var userInfoDtoList = query.ProjectTo<UserInfoDto>();

                foreach (var item in userInfoDtoList)
                {
                    Console.WriteLine($" name { item.Name}, adress {item.Adress}");
                }
            }
            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}