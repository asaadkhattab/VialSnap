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
        //Many-to-Many Relationship
        public Patient()
        {
            Physicians = new List<PatientPhysician>();
        }

        public int PatientId { get; set; }

        public int BasicId { get; set; } //Foreign Key Property
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PatientAge { get; set; }
        public string PatientDescription { get; set; }
        public DateTime PatientBirthDay { get; set; }
        public decimal? PatientWeight { get; set; }


        public Basic Basic { get; set; } //navigation Property


        public ICollection<PatientPhysician> Physicians { get; set; }
        public string DisplayText
        {
            get
            {
                return $"{Basic?.Title} #{PatientAge}";
            }
        }

        public void AddPhysician(Physician physician, Role role)
        {
            Physicians.Add(new PatientPhysician()
            {
                Physician = physician,
                Role = role
            });
        }
    }
}
