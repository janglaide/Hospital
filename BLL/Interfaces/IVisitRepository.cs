using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVisitRepository
    {
        IEnumerable<Visit> GetVisits();
        IEnumerable<Visit> GetVisitsByDoctor(int id);
        void AddVisit(Visit visit);
    }
}
