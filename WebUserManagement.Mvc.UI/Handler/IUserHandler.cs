using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUserManagement.DTO;

namespace WebUserManagement.Mvc.UI.Handler
{
    public interface IUserHandler
    {
        Task<long> CreateAsync(CreateUserRequest request);
        Task<long> UpdateAsync(long id, UpdateUserRequest request);
        Task<long> DeleteAsync(long id);
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(long id);
    }
}