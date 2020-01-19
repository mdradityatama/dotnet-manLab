using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManLab.Data;
using ManLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManLab.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ManLabDataContext _context;

        public CategoriesController(ManLabDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost()
        {
            string name = Request.Form["categoryName"];

            Category category = new Category
            {
                Name = name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index", "Categories");

        }

        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.Where(x => x.CategoryID == id).SingleOrDefault();

            return View(category);
        }

        [HttpPost]
        public IActionResult EditPost(int id)
        {
            Category category = _context.Categories.Where(x => x.CategoryID == id).SingleOrDefault();

            if (category != null)
            {
                string name = Request.Form["categoryName"];
                category.Name = name;
                _context.SaveChanges();
                ViewData["EditMessage"] = "Berhasil Edit Kategori";
                return RedirectToAction("Index", "Categories");
            }

            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            Category category = _context.Categories.Where(x => x.CategoryID == id).SingleOrDefault();

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                ViewData["DeleteMessage"] = "Berhasil hapus Kategori";
            }
            else
            {
                ViewData["DeleteMessage"] = "kategori tidak ada di database";
            }

            List<Category> categories = _context.Categories.ToList();

            return RedirectToAction("Index", categories);
        }

        public IActionResult Details(int id)
        {
            Category category = _context.Categories.Where(x => x.CategoryID == id).SingleOrDefault();

            return View(category);
        }
    }
}