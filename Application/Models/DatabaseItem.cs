using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Klasa odwzorowująca pojedynczy element bazy danych. W przeciwieństwie do <seealso cref="DatabaseItemCsvModel"/> nie jest ściśle związany z formatem pliku CSV.
    /// </summary>
    public class DatabaseItem
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
