using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminSite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            Models.ListItemModel listItems = new Models.ListItemModel();
            listItems.ListItemDisplay = new List<Models.ItemModel>();

            Models.ItemModel item = new Models.ItemModel();
            item.ValueMember = 0;
            item.DisplayName = "DisplayName";
            listItems.ListItemDisplay.Add(item);
            
            return View("~/Views/Shared/Index.cshtml", listItems);
        }
    }
}