using System.ComponentModel.DataAnnotations;

namespace WebUserManagement.DTO
{
    public class UpdateUserRequest
    {
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}