using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataManager
    {
        private IDoctorRepository doctorRepository;
        private IPatientRepository patientRepository;
        private ISpecializationRepository specializationRepository;
        private IVisitRepository visitRepository;
        private IVisitResultRepository visitResultRepository;

        public DataManager(IDoctorRepository doctor, IPatientRepository patient,
            ISpecializationRepository specialization, IVisitRepository visit,
            IVisitResultRepository visitResult)
        {
            doctorRepository = doctor;
            patientRepository = patient;
            specializationRepository = specialization;
            visitRepository = visit;
            visitResultRepository = visitResult;
        }

        public IDoctorRepository Doctors { get { return doctorRepository; } }
        public IPatientRepository Patients { get { return patientRepository; } }
        public ISpecializationRepository Specializations { get { return specializationRepository; } }
        public IVisitRepository Visits { get { return visitRepository; } }
        public IVisitResultRepository VisitResults { get { return visitResultRepository; } }
    }
}
