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
            List<Tool> tools = _context.Tools.Include(r => r.Room).Include(c => c.Category).ToList();

            return View(tools);
        }

        public IActionResult Create()
        {
            List<Category> categories = _context.Categories.ToList();
            List<Room> rooms = _context.Rooms.ToList();
            ViewData["Rooms"] = rooms;

            return View(categories);
        }

        [HttpPost]
        public IActionResult CreatePost()
        {
            string name = Request.Form["nameTool"];
            string categoriid = Request.Form["category"];
            string roomid = Request.Form["room"];

            Tool tool = new Tool
            {
                Name = name,
                CategoryID = int.Parse(categoriid),
                RoomID = int.Parse(roomid)
            };

            _context.Tools.Add(tool);
            _context.SaveChanges();

            return RedirectToAction("Index", "Tools");
        }

        public IActionResult Edit(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            return View(tool);
        }

        [HttpPost]
        public IActionResult EditPost(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            if (tool != null)
            {
                string name = Request.Form["toolName"];
                string category = Request.Form["category"];
                tool.Name = name;
                tool.CategoryID = int.Parse(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Tools");
            }

            return View("Edit", tool);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            if (tool != null)
            {
                _context.Tools.Remove(tool);
                _context.SaveChanges();
            }

            List<Tool> tools = _context.Tools.Include(c => c.Category).ToList();

            return RedirectToAction("Index", tool);
        }

        public IActionResult Details(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            return View(tool);
        }
    }
}