namespace Vet.Data
{
    public class Appointment
    {
        //zapisana konsultaciq - zabelejki, data....
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VetId { get; set; }
        public Vet Vet { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}

