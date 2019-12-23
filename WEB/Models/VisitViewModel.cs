using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VisitViewModel
    {
        public IEnumerable<Visit> Visits { get; set; }
    }
}