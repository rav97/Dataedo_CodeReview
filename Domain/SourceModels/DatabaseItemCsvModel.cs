using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SourceModels
{
    /// <summary>
    /// Model odzwierciedlający kolumny z pliku 'data.csv'
    /// </summary>
    public class DatabaseItemCsvModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
    }
}
