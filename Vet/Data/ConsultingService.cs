using System.ComponentModel.DataAnnotations;

namespace Vet.Data
{
    public class ConsultingService
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

