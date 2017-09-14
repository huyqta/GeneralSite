using AdminSite.Helpers;
using EntityModel;
using EntityModel.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly GeneralContext _context;

		IConfiguration _configuration;

        public CategoriesController(GeneralContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.Where(c=>c.Id != -1).ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .SingleOrDefaultAsync(m => m.Id == id);
            category.Parent = _context.Category.Where(cat => cat.Id == category.ParentId).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var cat in _context.Category.Where(cat => cat.ParentId == -1))
            {
                listItems.Add(new SelectListItem() { Value = cat.Id.ToString(), Text = cat.Name });
            }
            ViewBag.Categories = listItems;
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ParentId,ImageUrl,Description")] Category category, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
					GoogleApis ga = new GoogleApis(_configuration);
					category.ImageUrl = ga.UploadFile(file.FileName, file.ContentType, file.OpenReadStream(), Commons.ConstantUploadPath.CATEGORY);    
                }
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var cat in _context.Category.Where(cat => cat.ParentId == -1))
            {
                listItems.Add(new SelectListItem() { Value = cat.Id.ToString(), Text = cat.Name });
            }
            ViewBag.Categories = listItems;

            var category = await _context.Category.SingleOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl,ParentId,Description")] Category category, IFormFile file)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        GoogleApis ga = new GoogleApis(_configuration);
                        if (!ga.CheckFileExist(category.ImageUrl))
                        {
                            category.ImageUrl = ga.UploadFile(file.FileName, file.ContentType, file.OpenReadStream(), Commons.ConstantUploadPath.CATEGORY);
                        }
                    }
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .SingleOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.SingleOrDefaultAsync(m => m.Id == id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult GetAllProductImagesByCategory(string prefix)
        {
            GoogleApis ga = new GoogleApis(_configuration);
            var images = ga.GetAllProductImagesByCategory(prefix);
            //var res = JsonConvert.SerializeObject(images);
            return Json(images);
        }

        [HttpPost]
        public IActionResult GetAllCategories()
        {
            GoogleApis ga = new GoogleApis(_configuration);
            var categories = ga.GetAllCategories();
            //var res = JsonConvert.SerializeObject(images);
            return Json(categories);
        }
    }

    public class CloudStorageOptions
    {
        public string BucketName { get; set; } = "huyquan-images";
        public string ObjectName { get; set; } = "sample.txt";
    }
}
