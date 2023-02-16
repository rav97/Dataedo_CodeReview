using Application.Mappers.Interfaces;
using Application.Models;
using Domain.SourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class DatabaseItemMapper : IObjectMapper<DatabaseItemCsvModel, DatabaseItem>
    {
        public DatabaseItemCsvModel MappObject(DatabaseItem obj)
        {
            return new DatabaseItemCsvModel
            {
                DataType = obj.DataType,
                IsNullable = obj.IsNullable,
                Name = obj.Name,
                ParentName = obj.ParentName,
                ParentType = obj.ParentType,
                Schema = obj.Schema,
                Type = obj.Type
            };
        }

        public DatabaseItem MappObject(DatabaseItemCsvModel obj)
        {
            return new DatabaseItem
            {
                DataType = obj.DataType,
                IsNullable = obj.IsNullable,
                Name = obj.Name,
                ParentName = obj.ParentName,
                ParentType = obj.ParentType,
                Schema = obj.Schema,
                Type = obj.Type
            };
        }
    }
}
