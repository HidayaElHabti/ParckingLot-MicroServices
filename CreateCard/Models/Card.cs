using CreateCard.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateCard.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string carNumber { get; set; }
        public string carBrand { get; set; }
        public string carModel { get; set; }
        public int Balance { get; set; }
        public DateTime? lastEntered { get; set; }

        public Card()
        {
            Balance = 10;
            lastEntered = null;
        }

        public Card(CreateCardDto c)
        {
            carNumber = c.carNumber;
            carBrand = c.carBrand;
            carModel = c.carModel;
            Balance = 10;
            lastEntered = null;
        }
    }
}
