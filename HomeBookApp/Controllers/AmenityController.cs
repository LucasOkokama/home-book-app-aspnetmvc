using HomeBookApp.Application.Common.Interfaces;
using HomeBookApp.Domain.Entities;
using HomeBookApp.Infrastructure.Data;
using HomeBookApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomeBookApp.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var amenities = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
            return View(amenities);
        }

        public IActionResult Create()
        {
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    })
            };

            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Add(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            obj.VillaList = _unitOfWork.Villa.GetAll().Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    });

            return View(obj);
        }

        public IActionResult Update(int amenityId)
        {
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    }),

                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };

            if(amenityVM.Amenity == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Update(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            obj.VillaList = _unitOfWork.Villa.GetAll().Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    });

            return View(obj);
        }

        public IActionResult Delete(int amenityId)
        {
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(
                    x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    }),

                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };

            if (amenityVM.Amenity == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Delete(AmenityVM obj)
        {
            Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == obj.Amenity.Id);
            if (objFromDb is not null)
            {
                _unitOfWork.Amenity.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The Amenity could not be deleted.";
            return View();
        }
    }
}
