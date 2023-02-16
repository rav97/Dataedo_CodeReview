using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DatabaseItemInfo
    {
        public DatabaseItem Item { get; set; }
        public int NumberOfChildren { get; set; }

        public DatabaseItemInfo() { }
        public DatabaseItemInfo(DatabaseItem item, ICollection<DatabaseItem> itemsCollection)
        {
            this.Item = item;
            this.NumberOfChildren = itemsCollection?.Where(e => e.ParentType == item.Type && e.ParentName == item.Name)?.Count() ?? 0;
        }
    }
}
