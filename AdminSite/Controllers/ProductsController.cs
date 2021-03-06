﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityModel;
using EntityModel.Entity;
using AdminSite.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using AdminSite.Models;

namespace AdminSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly GeneralContext _context;
        IConfiguration _configuration;

        public ProductsController(GeneralContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var generalContext = _context.Product.Include(p => p.Category);
            return View(await generalContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            List<SelectListItem> listCategories = new List<SelectListItem>();
            foreach (var cat in _context.Category)
            {
                if (cat.Id < 0) continue;
                listCategories.Add(new SelectListItem() { Value = cat.Id.ToString(), Text = cat.Name });
            }
            ViewBag.Categories = listCategories;

            List<SelectListItem> listUnits = new List<SelectListItem>();
            var enumUnits = Enum.GetValues(typeof(Commons.Enums.UnitType));
            foreach (var unit in enumUnits)
            {
                listUnits.Add(new SelectListItem() { Value = unit.ToString(), Text = unit.ToString() });
            }
            ViewBag.Units = listUnits;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Price,ImageUrl,Description,UnitItem")] Product product, IFormFile file)
        {
            if (ModelState.IsValid && product.UnitItem != null)
            {
                //GoogleApis ga = new GoogleApis(_configuration);
                //product.ImageUrl = ga.UploadFile(file.FileName, file.ContentType, file.OpenReadStream(), Commons.ConstantUploadPath.PRODUCT);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<SelectListItem> listCategories = new List<SelectListItem>();
            foreach (var cat in _context.Category)
            {
                if (cat.Id < 0) continue;
                listCategories.Add(new SelectListItem() { Value = cat.Id.ToString(), Text = cat.Name });
            }
            ViewBag.Categories = listCategories;

            List<SelectListItem> listUnits = new List<SelectListItem>();
            var enumUnits = Enum.GetValues(typeof(Commons.Enums.UnitType));
            foreach (var unit in enumUnits)
            {
                listUnits.Add(new SelectListItem() { Value = unit.ToString(), Text = unit.ToString() });
            }
            ViewBag.Units = listUnits;
            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Price,ImageUrl,Description,UnitItem")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
