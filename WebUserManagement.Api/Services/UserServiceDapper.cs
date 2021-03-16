using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.Api.DTO;

namespace WebUserManagement.Api.Services
{
    public class UserServiceDapper : IUserService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UserServiceDapper(IRepository repository, IMapper mapper)
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
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).Select(u => _mapper.Map<UserResponse>(u));
        }

        public async Task<long> UpdateAsync(long id, UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = id;
            return await _repository.UpdateAsync(user);
        }
    }
}