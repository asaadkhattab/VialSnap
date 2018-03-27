using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class MedicationViewModel
    {
        [Required(ErrorMessage = "Enter the Medication please.")]
        public int? MedicationId { get; set; }


        public string Name { get; set; }
    }
}