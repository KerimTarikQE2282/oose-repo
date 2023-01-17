using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class PatientDbContext :DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options):base(options)

        {

        }
        public DbSet<Patients> Patients{ get; set; }
        
    }
}
