using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PatientController : Controller
    {
        private DataManager dataManager;
        public PatientController(DataManager data)
        {
            dataManager = data;
        }
        // GET: Patient
        public ActionResult Index()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patients = dataManager.Patients.GetPatients();
            return View(patientViewModel);
        }
        public ActionResult Diagnosis(int id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Diagnosises = dataManager.VisitResults.GetVisitResultsByPatient(id);
            return View(patientViewModel);
        }
    }
}