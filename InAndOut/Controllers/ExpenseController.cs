using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBCOntext _db; //dependency injection
        public ExpenseController(ApplicationDBCOntext db) // Consturctor
        {
            _db = db;
        }
        //GET-Create
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

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
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); // redirect to same controller once you post data from form to database
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Delete(int? id) //id is optionals so it is question mark
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
              if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
        
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
