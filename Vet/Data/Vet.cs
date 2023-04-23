namespace Vet.Data
{
    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Vaccine> Vaccines { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
