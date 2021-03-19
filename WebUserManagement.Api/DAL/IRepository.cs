using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.Api.DAL
{
    public interface IRepository
    {
        Task<long> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(long id);
    }
}
