using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientTitle { get; set; }
        public int PatientAge { get; set; }
        public string PatientDescription { get; set; }
        public DateTime PatientBirthDay { get; set; }

    }
}
