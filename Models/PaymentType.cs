using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
