using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Medication { get; set; }
    }
}
