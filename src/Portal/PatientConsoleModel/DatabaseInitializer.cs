using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PatientConsoleModel.Models;

namespace PatientConsoleModel
{
    internal  class DatabaseInitializer
        : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var basic = new Basic()
            {
                Title = "Asaads"
            };

            var basic2 = new Basic()
            {
                Title = "John Suan"
            };

            var basic3 = new Basic()
            {
                Title = "Stacy Adams"
            };


            //Physician Names
            var physician = new Physician()
            {
                Name = "Dr. Smith"
            };

            var physician2 = new Physician()
            {
                Name = "Dr. James"
            };

            var physician3 = new Physician()
            {
                Name = "Dr. William"
            };


            //Physician Roles
            var role1 = new Role()
            {
                Name = "Pediatrician"
            };

            var role2 = new Role()
            {
                Name = "Cardiologist"
            };

            var role3 = new Role()
            {
                Name = "General Surgeon"
            };

            var role4 = new Role()
            {
                Name = "Dermatologist"
            };

            var role5 = new Role()
            {
                Name = "Oncologist"
            };

            //Patients
            var patient = new Patient()
            {
                Basic = basic,
                PatientFirstName = "Asaad",
                PatientLastName = "s",
                PatientAge = 25,
                PatientBirthDay = DateTime.Today,
                PatientWeight = 2
            };
            patient.AddPhysician(physician, role1);
            patient.AddPhysician(physician, role2);


            var patient2 = new Patient()
            {
                Basic = basic2,
                PatientFirstName = "James",
                PatientLastName = "s",
                PatientAge = 25,
                PatientBirthDay = DateTime.Today,
                PatientWeight = 2
            };

            patient.AddPhysician(physician, role1);
            patient.AddPhysician(physician, role2);


            var patient3 = new Patient()
            {
                Basic = basic3,
                PatientFirstName = "b",
                PatientLastName = "g",
                PatientAge = 25,
                PatientBirthDay = DateTime.Today,
                PatientWeight = 2
            };

            patient.AddPhysician(physician, role1);
            patient.AddPhysician(physician, role2);

            context.Patients.Add(patient);
            context.Patients.Add(patient2);
            context.Patients.Add(patient3);


            context.SaveChanges();
        }
    }
}
