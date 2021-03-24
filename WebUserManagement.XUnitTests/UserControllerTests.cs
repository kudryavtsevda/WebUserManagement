using FakeItEasy;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebUserManagement.Api.Controllers;
using WebUserManagement.Api.Services;
using WebUserManagement.DTO;
using Xunit;

namespace WebUserManagement.XUnitTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Get_All_Should_Return_Users_And_Ok_StatusCode()
        {
            IUserService userServiceFake = A.Fake<IUserService>();

            A.CallTo(() => userServiceFake.GetAllAsync()).Returns(A.CollectionOfFake<UserResponse>(1));

            var controller = new UserController(userServiceFake);
            var res = (await controller.GetAll());

            var contentResult = res.As<OkNegotiatedContentResult<IEnumerable<UserResponse>>>();

            contentResult.Should().NotBeNull();
            contentResult.Content.Should().NotBeNull();
            contentResult.Content.Count().Should().Be(1);
        }

        [Fact]
        public async Task Create_Should_Return_User_Id_And_Ok_StatusCode()
        {
            long userId = 43;
            IUserService userServiceFake = A.Fake<IUserService>();
            A.CallTo(() => userServiceFake.CreateAsync(A<CreateUserRequest>.Ignored)).Returns(userId);

            var controller = new UserController(userServiceFake);
            var res = await controller.Create(A.Dummy<CreateUserRequest>());

            var contentResult = res.As<OkNegotiatedContentResult<long>>();

            contentResult.Should().NotBeNull();
            contentResult.Content.Should().Be(userId);
        }

        [Fact]
        public async Task Delete_Should_Return_Deleted_User_Id_And_Ok_StatusCode()
        {
            long userId = 43;
            IUserService userServiceFake = A.Fake<IUserService>();
            A.CallTo(() => userServiceFake.DeleteAsync(A<long>.Ignored)).Returns(userId);

            var controller = new UserController(userServiceFake);
            var res = await controller.Delete(userId);

            var contentResult = res.As<OkNegotiatedContentResult<long>>();

            contentResult.Should().NotBeNull();
            contentResult.Content.Should().Be(userId);
        }

        [Fact]
        public async Task Update_Should_Return_Deleted_User_Id_And_Ok_StatusCode()
        {
            long userId = 43;
            IUserService userServiceFake = A.Fake<IUserService>();
            A.CallTo(() => userServiceFake.UpdateAsync(A<long>.Ignored, A<UpdateUserRequest>.Ignored)).Returns(userId);

            var controller = new UserController(userServiceFake);
            var res = await controller.Update(userId, A.Dummy<UpdateUserRequest>());

            var contentResult = res.As<OkNegotiatedContentResult<long>>();

            contentResult.Should().NotBeNull();
            contentResult.Content.Should().Be(userId);
        }

        [Fact]
        public async Task GetById_Should_Return_User_And_Ok_StatusCode()
        {
            IUserService userServiceFake = A.Fake<IUserService>();
            A.CallTo(() => userServiceFake.GetByIdAsync(A<long>.Ignored)).Returns(A.Dummy<UserResponse>());

            var controller = new UserController(userServiceFake);
            var res = await controller.GetById(A.Dummy<long>());

            var contentResult = res.As<OkNegotiatedContentResult<UserResponse>>();

            contentResult.Should().NotBeNull();
            contentResult.Content.Should().NotBeNull();
        }
    }
}
