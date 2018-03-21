using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PatientPortal.Models;

namespace PatientPortal.Controllers
{
    public class PhysicianController : Controller
    {

        public static List<Physician> Doctor = new List<Physician>
        {
                    new Physician {PhysicianId = 1, Title = "Dr.", LastName ="William", FirstName = "Conner"},
                    new Physician {PhysicianId = 2, Title = "Dr.", LastName ="Samantha", FirstName = "Greene"},
                    new Physician {PhysicianId = 3, Title = "Dr.", LastName ="Serena", FirstName = "Patrick"},
                    new Physician {PhysicianId = 4, Title = "Dr.", LastName ="James", FirstName = "Begley"}

        };
        //Manage Physicians.
        // GET: Physician
        public ActionResult Index()
        {
            var physicianList = new PhysicianList
            {
                Doctor = Doctor.Select(p => new PhysicianViewModel
                {
                    PhysicianId = p.PhysicianId,
                        Title = p.Title,
                        LastName = p.LastName,
                        FirstName = p.FirstName
                        }).ToList()
                    };

            physicianList.TotalPhysician = physicianList.Doctor.Count;
            return View(physicianList);
        }

        public ActionResult PhysicianDetail (int id)
        {
            var physician = Doctor.SingleOrDefault(p => p.PhysicianId == id);
            if (physician != null)
            {
                var physicianViewModel = new PhysicianViewModel
                {
                    PhysicianId = physician.PhysicianId,
                    Title = physician.Title,
                    LastName = physician.LastName,
                    FirstName = physician.FirstName
                };

                return View(physicianViewModel);
            }
            return new HttpNotFoundResult();
        }

        //Add a Physician manually
        public ActionResult PhysicianAdd()
        {
            var physicianViewModel = new PhysicianViewModel();

            return View("AddEditPhysician", physicianViewModel);
        }

        [HttpPost]
        public ActionResult AddPhysician(PhysicianViewModel physicianViewModel)
        {
            var nextPhysicianId = Doctor.Max(p => p.PhysicianId) + 1;

            var physician = new Physician
            {
                PhysicianId = nextPhysicianId,
                LastName = physicianViewModel.LastName,
                FirstName = physicianViewModel.FirstName
            };

            Doctor.Add(physician);

            return RedirectToAction("Index");
        }

        //Edit a Physician manually

        public ActionResult PhysicianEdit(int id)
        {
            var physician = Doctor.SingleOrDefault(p => p.PhysicianId == id);
            if (physician != null)
            {
                var physicianViewModel = new PhysicianViewModel
                {
                    PhysicianId = physician.PhysicianId,
                    LastName = physician.LastName,
                    FirstName = physician.FirstName
                };

                return View("AddEditPhysician", physicianViewModel);
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]

        public ActionResult EditPhysician(PhysicianViewModel physicianViewModel)
        {
            var physician = Doctor.SingleOrDefault(p => p.PhysicianId == physicianViewModel.PhysicianId);

            if (physician != null)
            {
                physician.LastName = physicianViewModel.LastName;
                physician.FirstName = physicianViewModel.FirstName;

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }

        //Delete Physician
        [HttpPost]
        public ActionResult DeletePhysician(PhysicianViewModel physicianViewModel)
        {
            var person = Doctor.SingleOrDefault(p => p.PhysicianId == physicianViewModel.PhysicianId);

            if (person != null)
            {
                Doctor.Remove(person);

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }

    }
}

 