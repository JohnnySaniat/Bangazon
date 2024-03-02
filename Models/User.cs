using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Uid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsSeller { get; set; }
    }
}
