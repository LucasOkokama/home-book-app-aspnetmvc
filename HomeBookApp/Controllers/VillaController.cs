using HomeBookApp.Domain.Entities;
using HomeBookApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookApp.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("Description", "The description cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.Find(villaId);
            
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj, int villaId)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("Description", "The description cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                obj.Id = villaId;
                _db.Villas.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
