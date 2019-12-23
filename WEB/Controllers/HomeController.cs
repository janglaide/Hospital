using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private DataManager dataManager;
        public HomeController(DataManager dm)
        {
            dataManager = dm;
        }
        public ActionResult Index()
        {
            VisitsViewModel visitsViewModel = new VisitsViewModel();
            var visits = dataManager.Visits.GetVisits();
            visitsViewModel.Visits = visits;

            var doctors = dataManager.Doctors.GetDoctors();
            var patients = dataManager.Patients.GetPatients();

            var doctornames = from x in visits
                                         join t in doctors on x.DoctorId equals t.DoctorId
                                         select t.Name;
            visitsViewModel.DoctorName = doctornames.ToList();

            var doctorsurnames = from x in visits
                              join t in doctors on x.DoctorId equals t.DoctorId
                              select t.Surname;
            visitsViewModel.DoctorSurname = doctorsurnames.ToList();

            var patientnames = from x in visits
                              join t in patients on x.PatientId equals t.PatientId
                              select t.Name;
            visitsViewModel.PatientName = patientnames.ToList();

            var patientsurnames = from x in visits
                               join t in patients on x.PatientId equals t.PatientId
                               select t.Surname;
            visitsViewModel.PatientSurname = patientsurnames.ToList();

            return View(visitsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}