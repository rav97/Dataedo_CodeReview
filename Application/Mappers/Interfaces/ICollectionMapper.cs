using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Interfaces
{
    public interface ICollectionMapper<T1, T2> where T1 : class where T2 : class
    {
        ICollection<T1> MappCollection(ICollection<T2> obj);
        ICollection<T2> MappCollection(ICollection<T1> obj);
    }
}
