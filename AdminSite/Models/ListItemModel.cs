using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Models
{

    public class ListItemModel
    {
        public List<ItemModel> ListItemDisplay { get; set; }
    }

    public class ItemModel
    {
        public int ValueMember { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DownloadUrl { get; set; }
    }
}
