using System.Web.Mvc;
using Portal.Models;
using System.Linq;

namespace Portal.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            using (var portalContext = new PortalContext())
            {
                var patientList = new PatientListViewModel
                {
                    //Patient to a View Model
                    Patients = portalContext.Patients.Select(pat => new PatientViewModel
                    {
                        PatientId = pat.PatientId,
                        Prefix = pat.Prefix,
                        FirstName = pat.FirstName,
                        MiddleName = pat.MiddleName,
                        LastName = pat.LastName,
                        Suffix = pat.Suffix,
                        AccountBalance = pat.AccountBalance,

                        Medication = new MedicationViewModel
                        {
                            MedicationId = pat.MedicationId,
                            Name = pat.FirstName
                        },




                    }).ToList()
                };

                patientList.TotalPatients = patientList.Patients.Count;

                return View(patientList);
            }
        }

        //Patient Details
        public ActionResult PatientDetail(int id)
        {
            using (var portalContext = new PortalContext())
            {
                var patient = portalContext.Patients.SingleOrDefault(pat => pat.PatientId == id);
                if (patient != null)
                {
                    var patientViewModel = new PatientViewModel
                    {
                        PatientId = patient.PatientId,
                        Prefix = patient.Prefix,
                        FirstName = patient.FirstName,
                        MiddleName = patient.MiddleName,
                        LastName = patient.LastName,
                        Suffix = patient.Suffix,
                        AccountBalance = patient.AccountBalance,


                        Medication = new MedicationViewModel
                        {
                            MedicationId = patient.MedicationId,
                            Name = patient.Medication.Name
                        },



                    };

                    return View(patientViewModel);
                }
            }

            return new HttpNotFoundResult();
        }






        //Add Patient
        public ActionResult PatientAdd()
        {
            using (var portalContext = new PortalContext())
            {
                ViewBag.Medications = portalContext.Medications.Select(m => new SelectListItem
                {
                    Value = m.MedicationId.ToString(),
                    Text = m.Name
                }).ToList();


            }

            var patientViewModel = new PatientViewModel();

            return View("AddEditPatient", patientViewModel);
        }

        [HttpPost]
        public ActionResult AddPatient(PatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var portalContext = new PortalContext())
                {
                    ViewBag.Medications = portalContext.Medications.Select(m => new SelectListItem
                    {
                        Value = m.MedicationId.ToString(),
                        Text = m.Name
                    }).ToList();



                    return View("AddEditPatient", patientViewModel);
                }
            }

            using (var portalContext = new PortalContext())
            {
                var patient = new Patient
                {
                    Prefix = patientViewModel.Prefix,
                    FirstName = patientViewModel.FirstName,
                    MiddleName = patientViewModel.MiddleName,
                    LastName = patientViewModel.LastName,
                    Suffix = patientViewModel.Suffix,
                    AccountBalance = patientViewModel.AccountBalance,

                    MedicationId = patientViewModel.Medication.MedicationId.Value,

                };

                portalContext.Patients.Add(patient);
                portalContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult PatientEdit(int id)
        {
            using (var portalContext = new PortalContext())
            {
                ViewBag.Medications = portalContext.Medications.Select(m => new SelectListItem
                {
                    Value = m.MedicationId.ToString(),
                    Text = m.Name
                }).ToList();


                var patient = portalContext.Patients.SingleOrDefault(p => p.PatientId == id);


                if (patient != null)
                {
                    var patientViewModel = new PatientViewModel
                    {
                        PatientId = patient.PatientId,
                        Prefix = patient.Prefix,
                        FirstName = patient.FirstName,
                        MiddleName = patient.MiddleName,
                        LastName = patient.LastName,
                        Suffix = patient.Suffix,
                        AccountBalance = patient.AccountBalance,

                        Medication = new MedicationViewModel
                        {
                            MedicationId = patient.MedicationId,
                            Name = patient.Medication.Name
                        },



                    };

                    return View("AddEditPatient", patientViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditPatient(PatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var portalContext = new PortalContext())
                {

                    ViewBag.Medications = portalContext.Medications.Select(m => new SelectListItem
                    {
                        Value = m.MedicationId.ToString(),
                        Text = m.Name
                    }).ToList();

                    return View("AddEditPatient", patientViewModel);
                }
            }

            using (var portalContext = new PortalContext())
            {
                var patient = portalContext.Patients.SingleOrDefault(pat => pat.PatientId == patientViewModel.PatientId);

                if (patient != null)
                {
                    patient.Prefix = patientViewModel.Prefix;
                    patient.FirstName = patientViewModel.FirstName;
                    patient.MiddleName = patientViewModel.MiddleName;
                    patient.LastName = patientViewModel.LastName;
                    patient.Suffix = patientViewModel.Suffix;
                    patient.AccountBalance = patientViewModel.AccountBalance;

                    patient.MedicationId = patientViewModel.Medication.MedicationId.Value;

                    portalContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeletePatient(PatientViewModel patientViewModel)
        {
            using (var portalContext = new PortalContext())
            {
                var patient = portalContext.Patients.SingleOrDefault(p => p.PatientId == patientViewModel.PatientId);

                if (patient != null)
                {
                    portalContext.Patients.Remove(patient);
                    portalContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }
    }
}