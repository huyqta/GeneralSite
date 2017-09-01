using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminSite.Models;
using EntityModel;
using EntityModel.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminSite.Controllers
{
    public class CategoryController : Controller
    {
		private readonly GeneralContext _context;
        private readonly IMapper _mapper;

		public CategoryController(GeneralContext context, IMapper mapper)
		{
			_context = context;
            _mapper = mapper;
		}

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Models.ListItemModel listItems = new Models.ListItemModel();
            //listItems.ListItemDisplay = new List<Models.ItemModel>();

            //Models.ItemModel item = new Models.ItemModel();
            //item.ValueMember = 0;
            //item.DisplayName = "DisplayName";
            //listItems.ListItemDisplay.Add(item);
            //var categories = _context.Category;
            //CategoryModel model = _mapper.Map<CategoryModel, Category>(categories);
            //Category cat = _mapper.Map<CategoryModel, Category>(categories);
            //model = _context.
            return View();
        }

        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid){
                Category cat = _mapper.Map<CategoryModel, Category>(model);
                _context.Category.Add(cat);
                _context.SaveChanges();
            }

            return View();
        }
    }
}
