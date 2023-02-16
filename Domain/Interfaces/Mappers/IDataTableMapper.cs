using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Mappers
{
    public interface IDataTableMapper<T> where T : class
    {
        ICollection<T> MappFromDatatable(DataTable dt);
        DataTable MappToDatatable(ICollection<T> collection);
    }
}
