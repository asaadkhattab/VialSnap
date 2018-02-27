using PatientConsoleModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsoleModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //When we change the database
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Basic> Basics { get; set; }
    }


}
