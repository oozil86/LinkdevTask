using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentApp.Domain.IMapping
{
    public interface ITypeMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
