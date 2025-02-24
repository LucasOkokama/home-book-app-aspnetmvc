using HomeBookApp.Domain.Entities;
using HomeBookApp.Infrastructure.Data;
using HomeBookApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomeBookApp.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    })
            };

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            if (ModelState.IsValid)
            {
                if(_db.VillaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number))
                {
                    TempData["error"] = "The Villa number already exists.";
                }
                else
                {
                    _db.VillaNumbers.Add(obj.VillaNumber);
                    _db.SaveChanges();
                    TempData["success"] = "The Villa Number has been created successfully.";
                    return RedirectToAction("Index");
                }
            }

            obj.VillaList = _db.Villas.Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    });

            return View(obj);
        }

        public IActionResult Update(int VillaNumberId)
        {
            VillaNumber? obj = _db.VillaNumbers.Find(VillaNumberId);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(VillaNumber obj)
        {
            _db.VillaNumbers.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "The Villa Number has been updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int VillaNumberId)
        {
            VillaNumber? obj = _db.VillaNumbers.Find(VillaNumberId);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumber obj)
        {
            _db.VillaNumbers.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "The Villa Number has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
