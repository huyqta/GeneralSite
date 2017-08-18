using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralSite.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			var builder = new ConfigurationBuilder()
                .AddJsonFile("~/GeneralSite/appsettings.json", optional: false, reloadOnChange: true);

			var configuration = builder.Build();

			string connectionString = configuration.GetConnectionString("DefaultConnection");

			// Create an employee instance and save the entity to the database
            var entry = new Category() { Name = "John", Description = "Winston" };

			using (var context = GeneralContextFactory.Create(connectionString))
			{
				context.Add(entry);
				context.SaveChanges();
			}
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
