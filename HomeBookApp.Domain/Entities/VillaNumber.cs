﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HomeBookApp.Domain.Entities
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Villa Number")]
        public int Villa_Number { get; set; }

        [ForeignKey("Villa")]
        public int VillaId { get; set; }

        [ValidateNever]
        public Villa Villa { get; set; }

        [Display(Name = "Special Details")]
        public string? SpecialDetails { get; set; }
    }
}
