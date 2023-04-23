using Microsoft.AspNetCore.Identity;

namespace Vet.Data
{
    public class User:IdentityUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }//spestqvam ti 2 imena
        public ICollection<ConsultingService> ConsultingServices { get; set; }
        public ICollection<VaccineSchedule> VaccineSchedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}

