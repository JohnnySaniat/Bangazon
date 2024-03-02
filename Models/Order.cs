using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Uid { get; set; }
        public bool IsComplete { get; set; }

        public PaymentType PaymentType { get; set; }

        public int? PaymentTypeId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

