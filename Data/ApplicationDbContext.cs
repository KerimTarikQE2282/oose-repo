using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)

        {

        }
        public DbSet<Patients> Patients{ get; set; }
        public DbSet<Hospitals> Hospitals { get; set;}
        public DbSet<SystemUsers> SystemUsers { get; set; }
        public DbSet<Representatives> Representatives { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Vitals> Vitals { get; set; }   
        public DbSet<PatientDiagnosisNew> PatientDiagnosisNew { get; set; }
        public DbSet<DisgnosisAndPrescription> DisgnosisAndPrescription { get; set; }
        

    }
}
