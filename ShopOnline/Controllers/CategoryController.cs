using EntityModel;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    public class CategoryController : Controller
    {
        GeneralContext _context;

        public CategoryController(GeneralContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            model.ListProduct = _context.Product.Where(pro => pro.CategoryId == id).ToList();
            model.ActiveCategory = _context.Category.Where(cat => cat.Id == id).FirstOrDefault();
            model.ActiveCategoryId = id;
            return View(model);
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
