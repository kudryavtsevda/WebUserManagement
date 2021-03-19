using System.Linq;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL;
using System.Data.SqlClient;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.XUnitTests
{
    [TestCaseOrderer("WebUserManagement.XUnitTests.PriorityOrderer", "WebUserManagement.XUnitTests")]
    public class UserRepositoryTests
    {
        private readonly IRepository _repository;
        public UserRepositoryTests()
        {
            var configuration = new ConfigurationHelper().GetConfiguration();
            _repository = CreateRepository(configuration);
        }


        [Fact, TestPriority(1)]
        public async Task Delete_All_Users_Should_Remove_All_Users()
        {
            var users = await _repository.GetAllAsync();
            foreach (var user in users)
            {
                await _repository.DeleteAsync(user.Id);
            }

            var removedUsers = await _repository.GetAllAsync();
            removedUsers.Count().Should().Be(0);
        }

        [Fact, TestPriority(2)]
        public async Task Add_3_Users_Should_Add_3_Users_With_Id()
        {
            var userId1 = await _repository.CreateAsync(new User { FirstName = "John", LastName = "Smith", Email = "js@js.js" });
            var userId2 = await _repository.CreateAsync(new User { FirstName = "Pavel", LastName = "Garmov", Email = "pg@pg.pg" });
            var userId3 = await _repository.CreateAsync(new User { FirstName = "Andrey", LastName = "Khramov", Email = "ak@ak.ak" });

            var addedUsers = (await _repository.GetAllAsync()).Select(u => u.Id).ToHashSet();

            addedUsers.Should().Contain(userId1);
            addedUsers.Should().Contain(userId2);
            addedUsers.Should().Contain(userId3);
        }

        [Fact, TestPriority(3)]
        public async Task Update_Should_Change_User_FirsName_And_LastName()
        {
            var users = await _repository.GetAllAsync();
            foreach (var user in users)
            {
                user.FirstName = $"Name";
                user.LastName = $"Surname";
                await _repository.UpdateAsync(user);
            }

            var updatedUsers = await _repository.GetAllAsync();

            foreach (var user in updatedUsers)
            {
                user.FirstName.Should().Be("Name");
                user.LastName.Should().Be("Surname");
            }
        }

        [Fact, TestPriority(4)]
        public async Task Delete_Should_Remove_User_By_Id()
        {
            var userToBeRemovedId = (await _repository.GetAllAsync()).First().Id;
            await _repository.DeleteAsync(userToBeRemovedId);

            var removedUser = await _repository.GetByIdAsync(userToBeRemovedId);
            removedUser.Should().BeNull();
        }

        private IRepository CreateRepository(TestConfiguration configuration)
        {
            return new UserRepository(new SqlConnection(configuration.Connection));
        }
    }
}
