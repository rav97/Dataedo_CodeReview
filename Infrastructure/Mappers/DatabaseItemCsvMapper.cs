using Domain.Interfaces.Mappers;
using Domain.SourceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;

namespace Infrastructure.Mappers
{
    public class DatabaseItemCsvMapper : IDataTableMapper<DatabaseItemCsvModel>
    {
        public ICollection<DatabaseItemCsvModel> MappFromDatatable(DataTable dt)
        {
            ICollection<DatabaseItemCsvModel> result = new List<DatabaseItemCsvModel>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = new DatabaseItemCsvModel
                {
                    Type = dr[nameof(DatabaseItemCsvModel.Type)].ToString().RemoveAllWhitespaces().ToUpper(),
                    Name = dr[nameof(DatabaseItemCsvModel.Name)].ToString().RemoveAllWhitespaces(),
                    Schema = dr[nameof(DatabaseItemCsvModel.Schema)].ToString().RemoveAllWhitespaces(),
                    ParentName = dr[nameof(DatabaseItemCsvModel.ParentName)].ToString().RemoveAllWhitespaces(),
                    ParentType = dr[nameof(DatabaseItemCsvModel.ParentType)].ToString().RemoveAllWhitespaces().ToUpper(),
                    DataType = dr[nameof(DatabaseItemCsvModel.DataType)].ToString().RemoveAllWhitespaces(),
                    IsNullable = dr[nameof(DatabaseItemCsvModel.IsNullable)].ToString().RemoveAllWhitespaces(),
                };

                result.Add(item);
            }

            return result;
        }

        public DataTable MappToDatatable(ICollection<DatabaseItemCsvModel> collection)
        {
            throw new NotImplementedException();
        }
    }
}
