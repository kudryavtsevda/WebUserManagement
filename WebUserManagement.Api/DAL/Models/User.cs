using System.ComponentModel.DataAnnotations;

namespace WebUserManagement.Api.DAL.Models
{
    public class User
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}