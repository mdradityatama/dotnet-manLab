using ManLab.Data;
using ManLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ManLab.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ManLabDataContext _context;

        public ToolsController(ManLabDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Tool> tools = _context.Tools.Include(c => c.Category).ToList();

            return View(tools);
        }

        public IActionResult Create()
        {
            List<Category> categories = _context.Categories.ToList();

            return View(categories);
        }
        
        [HttpPost]
        public IActionResult CreatePost()
        {
            string name = Request.Form["nameTool"];
            string categoriid = Request.Form["category"];

            Tool tool = new Tool
            {
                Name = name,
                CategoryID = int.Parse(categoriid)
            };

            _context.Tools.Add(tool);
            _context.SaveChanges();

            return RedirectToAction("Index", "Tools");
        }
    }
}