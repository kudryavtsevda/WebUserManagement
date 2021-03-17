﻿using System.ComponentModel.DataAnnotations;

namespace WebUserManagement.Api.DTO
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