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
    public class SpecializationRepository : ISpecializationRepository
    {
        private HContext context;
        public SpecializationRepository(HContext arg)
        {
            context = arg;
        }
        public IEnumerable<Specialization> GetSpecializations()
        {
            return context.Specializations;
        }
    }
}
