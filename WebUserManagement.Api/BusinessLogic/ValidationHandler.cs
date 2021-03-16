using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUserManagement.Api.DTO;

namespace WebUserManagement.Api.BusinessLogic
{
    public class ValidationHandler : HandlerDecoratorBase<CreateUserRequest, long>
    {
        public ValidationHandler(HandlerDecoratorBase<CreateUserRequest, long> input) : base(input)
        {

        }

        public override long Handle(CreateUserRequest input)
        {
            //return !string.IsNullOrEmpty(input.Email);
            return 0;
        }
    }
}