using BLL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DoctorController : Controller
    {
        private DataManager dataManager;
        public DoctorController(DataManager dManager)
        {
            dataManager = dManager;
        }
        // GET: Doctor
        public ActionResult Index()
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            IEnumerable<Doctor> allDoctors = dataManager.Doctors.GetDoctors();

            doctorViewModel.Doctor = allDoctors;

            var specializatons = dataManager.Specializations.GetSpecializations();

            var Specs = from d in allDoctors
                        join t in specializatons on d.SpecializationId equals t.SpecializationId
                        select t.Name;
            doctorViewModel.connectedSpecializations = Specs.ToList();
            
            return View(doctorViewModel);
        }
        [HttpGet]
        public ActionResult DoctorsVisits(int id)
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.Visits = dataManager.Visits.GetVisitsByDoctor(id);
            
            return View(doctorViewModel);
        }
        
        [HttpPost]
        public ActionResult DoctorsVisits(DoctorViewModel model)
        {
            DateTime newDate;
            var flag = true;
            var parsingDate = DateTime.TryParse(model.DateBuffer, out newDate);
            if (parsingDate)
            {
                foreach(var x in dataManager.Visits.GetVisits())
                {
                    if(x.VisitTime == newDate)
                    {
                        flag = false;
                        break;
                    }
                    if(newDate.TimeOfDay < DateTime.Parse("01.01.2000 9:00:00").TimeOfDay ||
                        newDate.TimeOfDay >= DateTime.Parse("01.01.2000 20:00:00").TimeOfDay)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    var allPatients = dataManager.Patients.GetPatients();
                    int id = 0;
                    foreach (var x in allPatients)
                    {
                        if (x.Name == model.PatientName && x.Surname == model.PatientSurname)
                        {
                            id = x.PatientId;
                            break;
                        }
                    }
                    var newId = dataManager.Visits.GetVisits().Count() + 1;
                    var docId = dataManager.Visits.GetVisits().First().DoctorId;
                    if (id != 0)
                    {
                        dataManager.Visits.AddVisit(new Visit
                        {
                            VisitId = newId,
                            PatientId = id,
                            DoctorId = docId,
                            VisitTime = newDate
                        });
                    }
                    else
                    {
                        var newPatientId = dataManager.Patients.GetPatients().Count() + 1;
                        dataManager.Patients.AddPatient(new Patient
                        {
                            PatientId = newPatientId,
                            Name = model.PatientName,
                            Surname = model.PatientSurname
                        }) ;
                        dataManager.Visits.AddVisit(new Visit
                        {
                            VisitId = newId,
                            PatientId = newPatientId,
                            DoctorId = docId,
                            VisitTime = newDate
                        });
                    }
                    
                } 
            }
            return RedirectToAction("Index", "Home");
        }
    }
}