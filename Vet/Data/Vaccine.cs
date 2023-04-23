namespace Vet.Data
{
    public class Vaccine
    {
        //opisanie na samata vaksina + vruzka s grafika
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<VaccineSchedule> VaccineSchedules { get; set; }
    }
}
