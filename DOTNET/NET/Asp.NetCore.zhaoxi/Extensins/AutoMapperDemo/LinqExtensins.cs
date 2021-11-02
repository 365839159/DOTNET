using AutoMapper;
using AutoMapperDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    public static class LinqExtensins
    {
        public static IQueryable<T> ProjectTo<T>(this IQueryable query)
        {
            if (query == null)
            {
                throw new ArgumentNullException();
            }
            var config = new MapperConfiguration(config => { config.AddProfile(new AppProfile()); });

            var mapper = config.CreateMapper();

            return mapper.ProjectTo<T>(query);
        }
    }
}
