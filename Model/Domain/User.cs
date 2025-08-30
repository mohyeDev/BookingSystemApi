using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Roles? Roles { get; set; }
        public Guid RolesId { get; set; } 
    }
}
