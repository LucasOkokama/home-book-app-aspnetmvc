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
            bool roomNumberExists = _db.VillaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);
            
            if (ModelState.IsValid && !roomNumberExists)
            {
                _db.VillaNumbers.Add(obj.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been created successfully.";
                return RedirectToAction("Index");
            }

            if(roomNumberExists)
            {
                TempData["error"] = "The Villa number already exists.";
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
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    }),
                VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == VillaNumberId)
            };

            if(villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Index");
            }

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.VillaNumbers.Update(obj.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been updated successfully.";
                return RedirectToAction("Index");
            }

            obj.VillaList = _db.Villas.Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    });

            return View(obj);
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
