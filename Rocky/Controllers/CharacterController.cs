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
    }
}
