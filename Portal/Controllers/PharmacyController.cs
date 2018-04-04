using Portal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


//Controller to manage the Pharmacies.
namespace Portal.Controllers
{
    public class PharmacyController : Controller
    {

        // GET: Pharmacy
        public ActionResult Index()
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacyList = new PharmacyListViewModel
                {
                    Pharmacies = portalContext.Pharmacies.Select(p => new PharmacyViewModel
                    {
                        PharmacyId = p.PharmacyId,
                        Name = p.Name,
                        State = p.State,
                        City = p.City
                    }).ToList()
                };
                pharmacyList.TotalPharmacies = pharmacyList.Pharmacies.Count;
                return View(pharmacyList);
            }

        }

        //PHARMACY DETAIL 
        public ActionResult PharmacyDetail(int id)
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.SingleOrDefault(p => p.PharmacyId == id);
                if (pharmacy != null)
                {
                    var pharmacyViewModel = new PharmacyViewModel
                    {
                        PharmacyId = pharmacy.PharmacyId,
                        Name = pharmacy.Name,
                        State = pharmacy.State,
                        City = pharmacy.City
                    };
                    return View(pharmacyViewModel);

                }
            }
            return new HttpNotFoundResult();
        }


        //Add Pharmacy
        public ActionResult PharmacyAdd()
        {
            var pharmacyViewModel = new PharmacyViewModel();
            return View("AddEditPharmacy", pharmacyViewModel);
        }


        [HttpPost]
        public ActionResult AddPharmacy(PharmacyViewModel pharmacyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditPharmacy", pharmacyViewModel);
            }

            using (var portalContext = new PortalContext())
            {
                var pharmacy = new Pharmacy
                {
                    Name = pharmacyViewModel.Name,
                    City = pharmacyViewModel.City,
                    State = pharmacyViewModel.State
                };

                portalContext.Pharmacies.Add(pharmacy);
                portalContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Edit Pharmacy
        public ActionResult PharmacyEdit(int id)
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.SingleOrDefault(p => p.PharmacyId == id);
                if (pharmacy != null)
                {
                    var pharmacyViewModel = new PharmacyViewModel
                    {
                        PharmacyId = pharmacy.PharmacyId,
                        Name = pharmacy.Name,
                        City = pharmacy.City,
                        State = pharmacy.State
                    };
                    return View("AddEditPharmacy", pharmacyViewModel);
                }
            }
            return new HttpNotFoundResult();
        }


        //handle receiving updated pharmacy
        [HttpPost]
        public ActionResult EditPharmacy(PharmacyViewModel pharmacyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditPharmacy", pharmacyViewModel);
            }

            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.SingleOrDefault(p => p.PharmacyId == pharmacyViewModel.PharmacyId);

                if (pharmacy != null)
                {
                    pharmacy.Name = pharmacyViewModel.Name;
                    pharmacy.City = pharmacyViewModel.City;
                    pharmacy.State = pharmacyViewModel.State;
                    portalContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }

        //Delete
        [HttpPost]
        public ActionResult DeletePharmacy(PharmacyViewModel pharmacyViewModel)
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.SingleOrDefault(p => p.PharmacyId == pharmacyViewModel.PharmacyId);

                if (pharmacy != null)
                {
                    portalContext.Pharmacies.Remove(pharmacy);
                    portalContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }





        //Manage Controlled Substances
        public ActionResult ManageControlledSubstances(int id)
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.Include("MedControlledSubstances").SingleOrDefault(p => p.PharmacyId == id);

                if (pharmacy == null)
                    return new HttpNotFoundResult();

                var pharmacyViewModel = new PharmacyViewModel
                {
                    PharmacyId = pharmacy.PharmacyId,
                    Name = pharmacy.Name,
                    City = pharmacy.City,
                    State = pharmacy.State
                };

                foreach (var medication in portalContext.Medications.ToList())
                {
                    var currentSchedule = pharmacy.MedControlledSubstances.SingleOrDefault(mcss => mcss.MedicationId == medication.MedicationId)?.Schedule;

                    pharmacyViewModel.MedControlledSubstances.Add(new MedControlledSubstanceViewModel
                    {
                        Medication = new MedicationViewModel { MedicationId = medication.MedicationId, Name = medication.Name },
                        Schedule = currentSchedule ?? -1
                    });
                }
                return View(pharmacyViewModel);
            }
        }

        //Edit Controlled Suubstance
        [HttpPost]
        public ActionResult EditControlledSubstances(PharmacyViewModel pharmacyViewModel)
        {
            using (var portalContext = new PortalContext())
            {
                var pharmacy = portalContext.Pharmacies.Include("MedControlledSubstances").SingleOrDefault(p => p.PharmacyId == pharmacyViewModel.PharmacyId);

                if (pharmacy == null)
                    return new HttpNotFoundResult();

                foreach (var medControlledSubstance in pharmacyViewModel.MedControlledSubstances)
                {
                    if (medControlledSubstance.Schedule != -1)
                    {
                        var existingMedControlledSubstance = pharmacy.MedControlledSubstances.SingleOrDefault(mcss => mcss.MedicationId == medControlledSubstance.Medication.MedicationId);
                        if (existingMedControlledSubstance != null)
                        {
                            existingMedControlledSubstance.Schedule = medControlledSubstance.Schedule;
                        }
                        else
                        {
                            pharmacy.MedControlledSubstances.Add(new MedControlledSubstance
                            {
                                MedicationId = medControlledSubstance.Medication.MedicationId.Value,
                                Schedule = medControlledSubstance.Schedule
                            });
                        }
                    }
                }

                portalContext.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
    }