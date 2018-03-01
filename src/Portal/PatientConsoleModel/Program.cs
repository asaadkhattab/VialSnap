using PatientConsoleModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatientConsoleModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
  
                //Retrieve all patients from database
                var patients = context.Patients
                    .Include(p => p.Basic)
                    .Include(p => p.Physicians.Select(phys=> phys.Physician))
                    .Include(p => p.Physicians.Select(phys=> phys.Role))
                    .ToList();

                foreach (var patient in patients)
                {
                    var physicianRoleNames = patient.Physicians
                        .Select(phys => $"{phys.Physician.Name} - {phys.Role.Name}").ToList();
                    var physicianRoleDisplayText = string.Join(", ", physicianRoleNames);
                    Console.WriteLine(patient.DisplayText);
                    Console.WriteLine(physicianRoleDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}
