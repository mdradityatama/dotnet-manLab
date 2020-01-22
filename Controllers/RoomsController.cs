using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManLab.Data;
using ManLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManLab.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ManLabDataContext _context;

        public RoomsController(ManLabDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Room> rooms = _context.Rooms.ToList();

            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost()
        {
            string name = Request.Form["nameRoom"];

            Room room = new Room
            {
                Name = name
            };

            _context.Rooms.Add(room);
            _context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }

        public IActionResult Edit(int id)
        {
            Room room = _context.Rooms.Where(x => x.RoomID == id).SingleOrDefault();

            return View(room);
        }

        [HttpPost]
        public IActionResult EditPost(int id)
        {
            Room room = _context.Rooms.Where(x => x.RoomID == id).SingleOrDefault();

            if (room != null)
            {
                string name = Request.Form["toolName"];
                room.Name = name;
                _context.SaveChanges();
                return RedirectToAction("Index", "Rooms");
            }

            return View("Edit", room);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            Room room = _context.Rooms.Where(x => x.RoomID == id).SingleOrDefault();

            if(room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }

            List<Room> rooms = _context.Rooms.ToList();

            return RedirectToAction("Index", rooms);
        }

        public IActionResult Details(int id)
        {
            Room room = _context.Rooms.Where(x => x.RoomID == id).SingleOrDefault();

            return View(room);
        }
    }
}