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
    public class UserServiceEF : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;


        public UserServiceEF(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            var user = _context.Users.Add(_mapper.Map<User>(request));
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<long> DeleteAsync(long id)
        {
            var user = await GetUserByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return id;

        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().Select(u => _mapper.Map<User, UserResponse>(u)).ToListAsync();
        }

        public async Task<long> UpdateAsync(long id, UpdateUserRequest request)
        {
            var user = await GetUserByIdAsync(id);
            _mapper.Map(request, user);
            await _context.SaveChangesAsync();
            return id;
        }


        private async Task<User> GetUserByIdAsync(long id)
        {
            return await _context.Users.FindAsync(id)
                              ?? throw new NotFoundException($"User is not found with id {id}");
        }
    }
}