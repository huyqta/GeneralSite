using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminSite.Helpers;
using Microsoft.Extensions.Configuration;

namespace AdminSite.Controllers
{
    public class BaseController : Controller
    {
        IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAllImageProduct()
        {
            GoogleApis ga = new GoogleApis(_configuration);
            var res = ga.GetAllProductImages();
            return View(res);
        }
    }
}