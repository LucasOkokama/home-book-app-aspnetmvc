using HomeBookApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeBookApp.Web.ViewModels
{
    public class AmenityVM
    {
        public Amenity? Amenity { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
