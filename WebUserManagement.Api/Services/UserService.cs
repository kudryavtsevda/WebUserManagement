using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.Api.DTO;
using WebUserManagement.Api.Exceptions;

namespace WebUserManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;


        public UserService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            using (_context)
            {
                var user = _context.Users.Add(_mapper.Map<User>(request));
                await _context.SaveChangesAsync();
                return user.Id;
            }
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
                            .Select(u => _mapper.Map<User, UserResponse>(u));
            }
        }

        public async Task<long> UpdateAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}