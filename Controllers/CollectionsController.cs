using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManLab.Data;
using ManLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManLab.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ManLabDataContext _context;

        public CollectionsController(ManLabDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Collection> collections = _context.Collections
                                                   .Include(t => t.Tool)
                                                   .Include(c => c.Category)
                                                   .Include(r => r.Room)
                                                   .ToList();
            return View(collections);
        }

        public IActionResult Create()
        {
            List<Tool> tools = _context.Tools.ToList();
            List<Category> categories = _context.Categories.ToList();
            List<Room> rooms = _context.Rooms.ToList();

            ViewData["Tools"] = tools;
            ViewData["Categories"] = categories;
            ViewData["Rooms"] = rooms;

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost()
        {
            int tool = int.Parse(Request.Form["tool"]);
            int category = int.Parse(Request.Form["category"]);
            int room = int.Parse(Request.Form["room"]);
            int total = int.Parse(Request.Form["nameTotal"]);

            Collection collection = new Collection
            {
                ToolID = tool,
                CategoryID = category,
                RoomID = room,
                Total = total
            };

            _context.Collections.Add(collection);
            _context.SaveChanges();

            return RedirectToAction("Index", "Collections");

        }

        public IActionResult Edit(int id)
        {
            Collection collection = _context.Collections
                                            .Where(x => x.CollectionID == id)
                                            .Include(t => t.Tool)
                                            .Include(c => c.Category)
                                            .Include(r => r.Room)
                                            .SingleOrDefault();

            List<Tool> tools = _context.Tools.ToList();
            List<Category> categories = _context.Categories.ToList();
            List<Room> rooms = _context.Rooms.ToList();

            ViewData["Tools"] = tools;
            ViewData["Categories"] = categories;
            ViewData["Rooms"] = rooms;

            return View(collection);
        }

        [HttpPost]
        public IActionResult EditPost(int id)
        {
            Collection collection = _context.Collections
                                            .Where(x => x.CollectionID == id)
                                            .Include(t => t.Tool)
                                            .Include(c => c.Category)
                                            .Include(r => r.Room)
                                            .SingleOrDefault();
            
            if (collection != null)
            {
                int tool = int.Parse(Request.Form["tool"]);
                int category = int.Parse(Request.Form["category"]);
                int room = int.Parse(Request.Form["room"]);
                int total = int.Parse(Request.Form["nameTotal"]);
                collection.ToolID = tool;
                collection.CategoryID = category;
                collection.RoomID = room;
                collection.Total = total;
                _context.SaveChanges();
                return RedirectToAction("Index", "Collections");
            }

            return View("Edit", collection);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            Collection collection = _context.Collections
                                            .Where(x => x.CollectionID == id)
                                            .SingleOrDefault();
            
            if (collection != null)
            {
                _context.Collections.Remove(collection);
                _context.SaveChanges();
            }

            List<Collection> collections = _context.Collections
                                                   .Include(t => t.Tool)
                                                   .Include(c => c.Category)
                                                   .Include(r => r.Room)
                                                   .ToList();

            return RedirectToAction("Index", collections);
        }

        public IActionResult Details(int id)
        {
            Collection collection = _context.Collections
                                            .Where(x => x.CollectionID == id)
                                            .Include(t => t.Tool)
                                            .Include(c => c.Category)
                                            .Include(r => r.Room)
                                            .SingleOrDefault();

            return View(collection);
        }
    }
}