using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vialsnap.Models;

namespace Vialsnap.Controllers
{
    public class PatientController : Controller
    {

        // GET: Patient
        public ActionResult Index()
        {
            using (var vialsnapContext = new VialsnapContext())
            {
                var patientList = new PatientListViewModel
                {
                    //Convert Patient to Patient View Model
                    People = vialsnapContext.People.Select(p => new PatientViewModel
                    {
                        PatientId = p.PatientId,
                        Prefix = p.Prefix,
                        LastName = p.LastName,
                        MiddleName = p.MiddleName,
                        FirstName = p.FirstName,
                        Suffix = p.Suffix,

                        DateOfBirth = p.DateOfBirth,

                        AddressLine1 = p.AddressLine1,
                        AddressLine2 = p.AddressLine2,
                        State = p.State,
                        City = p.City,
                        Zip = p.Zip,

                        HomeNumber = p.HomeNumber,
                        CellNumber = p.CellNumber,
                        Email = p.Email,

                        AccountBalance = p.AccountBalance,

                        Medication = new MedicationViewModel
                        {
                            MedicationId = p.MedicationId,
                            Name = p.FirstName
                        }

                    }).ToList()
                };

                patientList.TotalPeople = patientList.People.Count;

                return View(patientList);
            }

        }

        // GET: Patient Detail
        public ActionResult PatientDetail(int id)
        {
            using (var vialsnapContext = new VialsnapContext())
            {

                var patient = vialsnapContext.People.SingleOrDefault(p => p.PatientId == id);
                if (patient != null)
                {

                        var patientViewModel = new PatientViewModel
                        {
                            PatientId = patient.PatientId,
                            Prefix = patient.Prefix,
                            LastName = patient.LastName,
                            MiddleName = patient.MiddleName,
                            FirstName = patient.FirstName,
                            Suffix = patient.Suffix,

                            DateOfBirth = patient.DateOfBirth,

                            AddressLine1 = patient.AddressLine1,
                            AddressLine2 = patient.AddressLine2,
                            State = patient.State,
                            City = patient.City,
                            Zip = patient.Zip,

                            HomeNumber = patient.HomeNumber,
                            CellNumber = patient.CellNumber,
                            Email = patient.Email,

                            AccountBalance = patient.AccountBalance,
                        };

                        return View(patientViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        //Add Patient

        public ActionResult PatientAdd()
        {
            using (var lunchContext = new VialsnapContext())
            {
                ViewBag.Medications = lunchContext.Medications.Select(c => new SelectListItem
                {
                    Value = c.MedicationId.ToString(),
                    Text = c.Name
                }).ToList();
            }
            var patientViewModel = new PatientViewModel();
            return View("AddEditPatient", patientViewModel);
        }

        [HttpPost]
        public ActionResult AddPatient(PatientViewModel patientViewModel)
        {
            using (var vialsnapContext = new VialsnapContext())
            {
                var patient = new Patient
                {
                    Prefix = patientViewModel.Prefix,
                    LastName = patientViewModel.LastName,
                    MiddleName = patientViewModel.MiddleName,
                    FirstName = patientViewModel.FirstName,
                    Suffix = patientViewModel.Suffix,

                   DateOfBirth = patientViewModel.DateOfBirth,

                    AddressLine1 = patientViewModel.AddressLine1,
                    AddressLine2 = patientViewModel.AddressLine2,
                    State = patientViewModel.State,
                    City = patientViewModel.City,
                    Zip = patientViewModel.Zip,

                    HomeNumber = patientViewModel.HomeNumber,
                    CellNumber = patientViewModel.CellNumber,
                    Email = patientViewModel.Email,

                    AccountBalance = patientViewModel.AccountBalance
                };

                vialsnapContext.People.Add(patient);
                vialsnapContext.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        //Edit Patient
        public ActionResult PatientEdit(int id)
        {
            using (var vialsnapContext = new VialsnapContext())
            {
                var patient = vialsnapContext.People.SingleOrDefault(p => p.PatientId == id);
                if (patient != null)
                {
                    var patientViewModel = new PatientViewModel
                    {
                        PatientId = patient.PatientId,
                        Prefix = patient.Prefix,
                        LastName = patient.LastName,
                        MiddleName = patient.MiddleName,
                        FirstName = patient.FirstName,
                        Suffix = patient.Suffix,

                        DateOfBirth = patient.DateOfBirth,

                        AddressLine1 = patient.AddressLine1,
                        AddressLine2 = patient.AddressLine2,
                        State = patient.State,
                        City = patient.City,
                        Zip = patient.Zip,

                        HomeNumber = patient.HomeNumber,
                        CellNumber = patient.CellNumber,
                        Email = patient.Email,

                        AccountBalance = patient.AccountBalance
                    };

                    return View("AddEditPatient", patientViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditPatient(PatientViewModel patientViewModel)
        {
            using (var vialsnapContext = new VialsnapContext())
            {
                var patient = vialsnapContext.People.SingleOrDefault(p => p.PatientId == patientViewModel.PatientId);

                if (patient != null)
                {
                    patient.Prefix = patientViewModel.Prefix;
                    patient.LastName = patientViewModel.LastName;
                    patient.MiddleName = patientViewModel.MiddleName;
                    patient.FirstName = patientViewModel.FirstName;
                    patient.Prefix = patientViewModel.Prefix;

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        //Delete
        [HttpPost]
        public ActionResult DeletePatient(PatientViewModel patientViewModel)
        {

            using (var vialsnapContext = new VialsnapContext())
            {
                var patient = vialsnapContext.People.SingleOrDefault(p => p.PatientId == patientViewModel.PatientId);

                if (patient != null)
                {
                    vialsnapContext.People.Remove(patient);

                    return RedirectToAction("Index");
                }

                return new HttpNotFoundResult();
            }
        }
    }
}