using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vet.Data
{
    public class ClinicDbContext : IdentityDbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineSchedule> VaccineSchedules { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ConsultingService> ConsultingServices { get; set; }
    }
}