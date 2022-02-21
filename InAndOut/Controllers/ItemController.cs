using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBCOntext _db; //dependency injection
        public ItemController(ApplicationDBCOntext db) // Consturctor
        {
            _db = db;
        }
        //GET-Create
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;

            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); // redirect to same controller once you post data from form to database
            }
            return View(obj);
         
        }
    }
}
