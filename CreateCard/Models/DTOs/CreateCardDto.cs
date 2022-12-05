using System.ComponentModel.DataAnnotations;

namespace CreateCard.Models.DTOs
{
    public class CreateCardDto
    {
        [Required]
        public string carNumber { get; set; }
        [Required]
        public string carBrand { get; set; }
        [Required]
        public string carModel { get; set; }
    }
}
