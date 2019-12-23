using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PatientViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<VisitResult> Diagnosises { get; set; }
    }
}