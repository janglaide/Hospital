using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DoctorViewModel
    {
        public IEnumerable<Doctor> Doctor { get; set; }
        public List<string> connectedSpecializations { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        public string DateBuffer { get; set; }

        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
    }
}