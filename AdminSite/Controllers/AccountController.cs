using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminSite.Helpers;
using AdminSite.Models;
using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminSite.Controllers
{
    public class AccountController : Controller
    {
		private readonly GeneralContext _context;

		public AccountController(GeneralContext context)
		{
			_context = context;
		}
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(AccountModel model)
        {
			if (string.IsNullOrEmpty(HttpContext.Session.GetString(AuthenticationHelper.SessionLogin)))
			{
				if (AuthenticationHelper.CheckAuthentication(_context, model))
				{
					HttpContext.Session.SetString(AuthenticationHelper.SessionLogin, model.Username);
                    return RedirectToAction("Index", "Home");
				}
			}
            return View();
        }
    }
}
