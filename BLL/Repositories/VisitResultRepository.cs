using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class VisitResultRepository : IVisitResultRepository
    {
        private HContext context;
        public VisitResultRepository(HContext arg)
        {
            context = arg;
        }
        public IEnumerable<VisitResult> GetVisitResults()
        {
            return context.VisitResults;
        }

        public IEnumerable<VisitResult> GetVisitResultsByPatient(int id)
        {
            IEnumerable<VisitResult> x = from a in context.VisitResults
                    join b in context.Visits on a.VisitId equals b.VisitId
                    join c in context.Patients on b.PatientId equals c.PatientId
                    where c.PatientId == id
                    select a;
            return x;
        }
    }
}
