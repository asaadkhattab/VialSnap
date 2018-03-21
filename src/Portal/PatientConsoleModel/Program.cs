using PatientConsoleModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace PatientConsoleModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                context.Database.Log = (message) => Debug.WriteLine(message);

  
 
    
                var patients = context.Patients
                    .Include(p => p.Basic)
                    .Include(p => p.Physicians.Select(phys => phys.Physician))
                    .Include(p => p.Physicians.Select(phys => phys.Role))
                    .ToList();

                foreach (var patient in patients)
                {

                    if (patient.Basic == null)
                    {
                        context.Entry(patient)
                            .Reference(p => p.Basic)
                            .Load();
                    }
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
