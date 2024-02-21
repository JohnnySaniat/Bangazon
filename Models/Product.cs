using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
    }
}
