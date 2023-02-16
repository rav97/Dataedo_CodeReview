using Application.Managers.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class DatabaseItemsInfoDisplayer : IConsoleDisplayer<ICollection<DatabaseItemInfo>>
    {
        public void DisplayOnConsole(ICollection<DatabaseItemInfo> obj)
        {
            var databaseObjects = obj.Where(o => o.Item.Type == "DATABASE").ToList();
            if (databaseObjects.Count > 0)
            {
                foreach (var databaseObject in databaseObjects)
                {
                    Console.WriteLine($"Database '{databaseObject.Item.Name}' ({databaseObject.NumberOfChildren} tables)");

                    var tableObjects = obj.Where(o => o.Item.Type == "TABLE"
                                                               && o.Item.ParentType == databaseObject.Item.Type
                                                               && o.Item.ParentName.ToUpper() == databaseObject.Item.Name.ToUpper())
                                                        .ToList();

                    foreach (var tableObject in tableObjects)
                    {
                        Console.WriteLine($"\tTable '{tableObject.Item.Schema}.{tableObject.Item.Name}' ({tableObject.NumberOfChildren} columns)");

                        var columnObjects = obj.Where(o => o.Item.Type == "COLUMN"
                                                                    && o.Item.ParentType == tableObject.Item.Type
                                                                    && o.Item.ParentName.ToUpper() == tableObject.Item.Name.ToUpper())
                                                        .ToList();

                        foreach (var columnObject in columnObjects)
                        {
                            Console.WriteLine($"\t\tColumn '{columnObject.Item.Name}' with {columnObject.Item.DataType} data type {(columnObject.Item.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                        }
                    }
                }
            }
        }
    }
}
