using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CharacterController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Character> objList = _db.Character;
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
        public IActionResult Create(Character obj)
        {
            _db.Character.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get for Edit
        public IActionResult Edit(int? Id)
        {
            var obj = _db.Character.Find(Id);
            if (Id.Equals(null) || Id.Equals(0) || obj.Equals(null))
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Character obj)
        {
            if (ModelState.IsValid)
            {
                _db.Character.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET for deleting
        public IActionResult Delete(int? Id)
        {
            var obj = _db.Character.Find(Id);
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
            var obj = _db.Character.Find(Id);
            if (Id.Equals(null) || Id.Equals(0) || obj.Equals(null))
            {
                return NotFound();
            }
            _db.Character.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
