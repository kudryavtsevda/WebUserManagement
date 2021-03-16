using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.Api.DTO;

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
