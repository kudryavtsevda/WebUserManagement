using System.Collections.Generic;
using System.Threading.Tasks;
using WebUserManagement.Api.DTO;

namespace WebUserManagement.Api.Services
{
    public interface IUserService
    {
        Task<long> CreateAsync(CreateUserRequest request);
        Task<long> UpdateAsync(long id, UpdateUserRequest request);
        Task<long> DeleteAsync(long id);
        Task<IEnumerable<UserResponse>> GetAllAsync();
    }
}
