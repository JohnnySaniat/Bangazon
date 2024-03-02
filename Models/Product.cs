using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Image { get; set; }

        [ForeignKey("ProductType")]
        public int? ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
