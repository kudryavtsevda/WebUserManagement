using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUserManagement.Api.DTO
{
    public class CreateUserRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}