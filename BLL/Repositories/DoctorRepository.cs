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
    public class DoctorRepository : IDoctorRepository
    {
        private HContext context;
        public DoctorRepository(HContext arg)
        {
            context = arg;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            return context.Doctors;
        }

        public IEnumerable<Doctor> GetDoctorsBySpecialization(int id)
        {
            return context.Doctors.Where(x => x.SpecializationId == id);
        }
    }
}
