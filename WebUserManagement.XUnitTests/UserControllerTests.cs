using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserManagement.Api.Controllers;
using WebUserManagement.Api.Services;
using WebUserManagement.DTO;
using Xunit;

namespace WebUserManagement.XUnitTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Get_All_Should_Return_UsersAsync()
        {
            IUserService userServiceFake = A.Fake<IUserService>();
            A.CallTo(() => userServiceFake.GetAllAsync()).Returns(new List<UserResponse>());

            var controller = new UserController(userServiceFake);
            var res = (await controller.GetAll());
            
          
        }
    }
}
