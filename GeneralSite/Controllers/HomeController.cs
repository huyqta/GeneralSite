using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GeneralSite.Models;
using Microsoft.Extensions.Configuration;
using EntityModel.Entity;
using EntityModel;

namespace GeneralSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly GeneralContext _context;

        public HomeController(GeneralContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var entry = new Category() { Name = "Nguyễn", Description = "Văn Trỗi" };
            _context.Add(entry);
            _context.SaveChanges();

            ViewBag.Categories = _context.Category.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
