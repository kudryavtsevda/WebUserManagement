using System.Collections.Generic;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.Api.DAL
{
    public interface IRepository
    {
        Task<long> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
