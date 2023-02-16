using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Interfaces
{
    public interface IObjectMapper<T1, T2> where T1 : class where T2 : class
    {
        T1 MappObject(T2 obj);
        T2 MappObject(T1 obj);
    }
}
