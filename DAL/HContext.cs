using DAL.Entities;
using System.Data.Entity;


namespace DAL
{
    public class HContext : DbContext
    {
        public HContext() : base("Context") { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitResult> VisitResults { get; set; }
    }
}
