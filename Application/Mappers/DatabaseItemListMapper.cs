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
    public class DatabaseItemListMapper : ICollectionMapper<DatabaseItemCsvModel, DatabaseItem>, ICollectionMapper<DatabaseItem, DatabaseItemInfo>
    {
        public ICollection<DatabaseItem> MappCollection(ICollection<DatabaseItemInfo> obj)
        {
            ICollection<DatabaseItem> result = new List<DatabaseItem>();
            foreach (DatabaseItemInfo dbi in obj)
            {
                result.Add(new DatabaseItem
                {
                    DataType = dbi.Item.DataType,
                    IsNullable = dbi.Item.IsNullable,
                    Name = dbi.Item.Name,
                    ParentName = dbi.Item.ParentName,
                    ParentType = dbi.Item.ParentType,
                    Schema = dbi.Item.Schema,
                    Type = dbi.Item.Type
                });
            }
            return result;
        }

        public ICollection<DatabaseItemInfo> MappCollection(ICollection<DatabaseItem> obj)
        {
            ICollection<DatabaseItemInfo> result = new List<DatabaseItemInfo>();
            foreach(DatabaseItem dbi in obj)
            {
                result.Add(new DatabaseItemInfo(dbi, obj));
            }
            return result;
        }

        public ICollection<DatabaseItem> MappCollection(ICollection<DatabaseItemCsvModel> obj)
        {
            ICollection<DatabaseItem> result = new List<DatabaseItem>();
            foreach (DatabaseItemCsvModel dbcm in obj)
            {
                result.Add(new DatabaseItem
                {
                    DataType = dbcm.DataType,
                    IsNullable = dbcm.IsNullable,
                    Name = dbcm.Name,
                    ParentName = dbcm.ParentName,
                    ParentType = dbcm.ParentType,
                    Schema = dbcm.Schema,
                    Type = dbcm.Type
                });
            }
            return result;
        }

        ICollection<DatabaseItemCsvModel> ICollectionMapper<DatabaseItemCsvModel, DatabaseItem>.MappCollection(ICollection<DatabaseItem> obj)
        {
            ICollection<DatabaseItemCsvModel> result = new List<DatabaseItemCsvModel>();
            foreach (DatabaseItem dbi in obj)
            {
                result.Add(new DatabaseItemCsvModel
                {
                    DataType = dbi.DataType,
                    IsNullable = dbi.IsNullable,
                    Name = dbi.Name,
                    ParentName = dbi.ParentName,
                    ParentType = dbi.ParentType,
                    Schema = dbi.Schema,
                    Type = dbi.Type
                });
            }
            return result;
        }
    }
}
