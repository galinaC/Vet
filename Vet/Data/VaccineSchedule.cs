namespace Vet.Data
{
    public class VaccineSchedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
