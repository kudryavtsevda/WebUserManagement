using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.Api.DTO;
using WebUserManagement.Api.Exceptions;

namespace WebUserManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            return await _repository.CreateAsync(_mapper.Map<User>(request));
        }

        public async Task<long> DeleteAsync(long id)
        {
            await GetUserByIdAsync(id);
            await _repository.DeleteAsync(id);
            return id;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).Select(u => _mapper.Map<UserResponse>(u));
        }

        public async Task<long> UpdateAsync(long id, UpdateUserRequest request)
        {
            var user = await GetUserByIdAsync(id);
            _mapper.Map(request, user);
            await _repository.UpdateAsync(user);           
            return id;
        }

        private async Task<User> GetUserByIdAsync(long id)
        {
            return await _repository.GetUserByIdAsync(id)
                              ?? throw new NotFoundException($"User is not found with id {id}");
        }
    }
}