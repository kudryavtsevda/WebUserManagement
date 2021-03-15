using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DTO;
using WebUserManagement.Api.Exceptions;

namespace WebUserManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        
        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<long> DeleteAsync(long id)
        {
            using (_context)
            {
                var user = await _context.Users.FindAsync(id)
                      ?? throw new NotFoundException($"User is not found with id {id}");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return id;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            using (_context)
            {
                return (await _context.Users.AsNoTracking().ToListAsync())
                            .Select(u => new UserResponse
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email
                            });
            }
        }

        public async Task<long> UpdateAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}