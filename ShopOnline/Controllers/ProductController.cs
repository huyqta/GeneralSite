using EntityModel;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        GeneralContext _context;

        public ProductController(GeneralContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            HomeViewModel model = new HomeViewModel();
            model.ListCategory = _context.Category.Where(cat => cat.Id != -1).ToList();
            model.ListProduct = _context.Product.Where(pro => pro.CategoryId == id).ToList();

            model.ActiveProduct = _context.Product.Where(pro => pro.Id == id).FirstOrDefault();
            model.ActiveCategory = _context.Category.Where(cat => cat.Id != model.ActiveProduct.CategoryId).FirstOrDefault();

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
