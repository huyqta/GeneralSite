using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models;
using EntityModel;
using Microsoft.AspNetCore.Http;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        GeneralContext _context;

        public HomeController(GeneralContext context)
        {
            _context = context;
            

        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            model.ListProduct = _context.Product.ToList();
            //HttpContext.Session.SetInt32("Page", 1);
            //HttpContext.Session.SetInt32("ItemPerPage", 4);
            return View(model);
        }

        public IActionResult About()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            return View(model);
        }

        public IActionResult Contact()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            return View(model);
        }

        public IActionResult Store()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            return View(model);
        }

        public IActionResult Delivery()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Search(string value)
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            model.ListProduct = _context.Product.Where(pro => pro.Name.Contains(value)).ToList();
            return View(model);
        }
    }
}
