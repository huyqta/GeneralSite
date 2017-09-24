using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminSite.Models;
using EntityModel;
using AdminSite.Helpers;
using AdminSite.Filters;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace AdminSite.Controllers
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
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(AuthenticationHelper.SessionLogin)))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(AccountModel model)
        //{            
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString(AuthenticationHelper.SessionLogin)))
        //    {
        //        if (AuthenticationHelper.CheckAuthentication(_context, model))
        //        {
        //            HttpContext.Session.SetString(AuthenticationHelper.SessionLogin, model.Username);
        //        }
        //    }
        //    ViewBag.SessionLogin = HttpContext.Session.GetString(AuthenticationHelper.SessionLogin);
        //    //var LoginInformation = HttpContext.Session.GetString(AuthenticationHelper.SessionLogin);
        //    return RedirectToAction("Index", "Home");
        //}

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

        public IActionResult InitData()
        {
            //var listcategory = System.IO.File.ReadAllLines(@"C:/Users/HUYQTA/Desktop/category.txt", Encoding.UTF8);
            //foreach (var line in listcategory)
            //{
            //    string id = line.Split('\t')[0];
            //    string name = line.Split('\t')[1];
            //    _context.Category.Add(new EntityModel.Entity.Category() { Id = int.Parse(id), Name = name, ParentId = -1 });
            //}
            //var listproduct = System.IO.File.ReadAllLines(@"C:/Users/HUYQTA/Desktop/product.txt", Encoding.UTF8);
            //foreach (var line in listproduct)
            //{
            //    string id = line.Split('\t')[0];
            //    string name = line.Split('\t')[1];
            //    string CatId = line.Split('\t')[2];
            //    string unitId = line.Split('\t')[6];
            //    _context.Product.Add(new EntityModel.Entity.Product() { Id = int.Parse(id), Name = name, CategoryId = int.Parse(CatId), UnitItem = unitId });
            //}
            //_context.SaveChanges();
            return View(_context.Product.ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
