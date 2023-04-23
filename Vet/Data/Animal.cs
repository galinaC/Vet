namespace Vet.Data
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; } 
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}

