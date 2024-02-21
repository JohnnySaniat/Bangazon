using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime PaymentTypeId { get; set; }
    }
}
