using AutoMapper;
using EmploymentApp.Domain.IMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentApp.Persistence.Mapping
{
    public class TypeMapper : ITypeMapper
    {
        public TypeMapper()
        {
        }


        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            }).CreateMapper();


            var mapping = mapper.Map<TDestination>(source);
            return mapping;
        }


    }
}
