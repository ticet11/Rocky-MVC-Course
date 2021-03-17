using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        // GET for Create
        public IActionResult Create()
        {
            return View();
        }

        // POST for Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET for editing
        public IActionResult Edit(int? Id)
        {
            var obj = _db.Category.Find(Id);
            if (Id.Equals(null) || Id.Equals(0) || obj.Equals(null))
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST for Editing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET for deleting
        public IActionResult Delete(int? Id)
        {
            var obj = _db.Category.Find(Id);
            if (Id.Equals(null) || Id.Equals(0) || obj.Equals(null))
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST for deleting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? Id)
        {
            var obj = _db.Category.Find(Id);
            if (Id.Equals(null) || Id.Equals(0) || obj.Equals(null))
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
