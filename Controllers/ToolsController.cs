﻿using ManLab.Data;
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
            List<Tool> tools = _context.Tools.ToList();

            return View(tools);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost()
        {
            string name = Request.Form["nameTool"];

            Tool tool = new Tool
            {
                Name = name
            };

            _context.Tools.Add(tool);
            _context.SaveChanges();

            return RedirectToAction("Index", "Tools");
        }

        public IActionResult Edit(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            return View(tool);
        }

        [HttpPost]
        public IActionResult EditPost(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            if (tool != null)
            {
                string name = Request.Form["toolName"];
                tool.Name = name;
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

            List<Tool> tools = _context.Tools.ToList();

            return RedirectToAction("Index", tool);
        }

        public IActionResult Details(int id)
        {
            Tool tool = _context.Tools.Where(x => x.ToolID == id).SingleOrDefault();

            return View(tool);
        }
    }
}