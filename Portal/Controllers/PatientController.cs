
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
                        FirstName = pat.FirstName,
                        Medication = new MedicationViewModel
                        {
                            MedicationId = pat.MedicationId,
                            Name = pat.FirstName
                        }
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
                        FirstName = patient.FirstName,
                        Medication = new MedicationViewModel
                        {
                            MedicationId = patient.MedicationId,
                            Name = patient.Medication.Name
                        }
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
            using (var portalContext = new PortalContext())
            {
                var patient = new Patient
                {
                    FirstName = patientViewModel.FirstName,
                    MedicationId = patientViewModel.Medication.MedicationId.Value
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
                        FirstName = patient.FirstName,
                        Medication = new MedicationViewModel
                        {
                            MedicationId = patient.MedicationId,
                            Name = patient.Medication.Name
                        }
                    };

                    return View("AddEditPatient", patientViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditPatient(PatientViewModel patientViewModel)
        {
            using (var portalContext = new PortalContext())
            {
                var patient = portalContext.Patients.SingleOrDefault(p => p.PatientId == patientViewModel.PatientId);

                if (patient != null)
                {
                    patient.FirstName = patientViewModel.FirstName;
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