using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VisitsViewModel
    {
        public IEnumerable<Visit> Visits { get; set; }
        public List<string> DoctorName { get; set; }
        public List<string> DoctorSurname { get; set; }
        public List<string> PatientName { get; set; }
        public List<string> PatientSurname { get; set; }
    }
}