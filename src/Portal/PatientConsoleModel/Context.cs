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
        public DbSet<Patient> Patients { get; set; }



    }
}
