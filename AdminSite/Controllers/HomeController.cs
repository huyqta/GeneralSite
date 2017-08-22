using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminSite.Models;
using EntityModel;
using AdminSite.Helpers;
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

        public IActionResult Index(AccountModel model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(AuthenticationHelper.SessionLogin)))
            {
                if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
                {

                    string md5Hash = AuthenticationHelper.getMd5Hash(model.Password);

                    if (_context.Account.Any(m => m.Username == model.Username && m.Password == md5Hash))
                    {
                        HttpContext.Session.SetString(AuthenticationHelper.SessionLogin, model.Username);
                    }
                }
            }
            ViewBag.SessionLogin = HttpContext.Session.GetString(AuthenticationHelper.SessionLogin);
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
