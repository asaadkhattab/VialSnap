using PatientConsoleModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Patients.Add(new Patient()
                {
                    PatientTitle = "Mr.",
                    PatientAge = 22,
                    PatientBirthDay = DateTime.Today
                });
                context.SaveChanges();

                //Retrieve all patients from database
                var patients = context.Patients.ToList();

                foreach(var patient in patients)
                {
                    Console.WriteLine(patient.PatientTitle);
                }

                Console.ReadLine();
            }
        }
    }
}
