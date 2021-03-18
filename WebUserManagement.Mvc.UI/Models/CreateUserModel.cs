using System.ComponentModel.DataAnnotations;

namespace WebUserManagement.Mvc.UI.Models
{
    public class CreateUserModel
    {
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}