using System.ComponentModel.DataAnnotations;

namespace CardsAPI.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CVC { get; set; }
    }
}
