using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.Api.DAL
{
    public class UserRepository : IRepository
    {        
        private readonly IDbConnection _connection;
        
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<long> CreateAsync(User user)
        {
            using (var connection = GetConnection())
            {
                return await connection.ExecuteScalarAsync<long>("AddUser",
                                new { LastName = user.LastName, FirstName = user.FirstName, Email = user.Email },
                                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteAsync(long id)
        {
            using (var connection = GetConnection())
            {
                await connection.ExecuteScalarAsync("DeleteUser", new { Id = id }, commandType: CommandType.StoredProcedure);              
            }           
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (var connection = GetConnection())
            {
                await connection.ExecuteScalarAsync("UpdateUser", user, commandType: CommandType.StoredProcedure); 
            }
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<User>("GetUserById", new { Id = id }, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();
            }
        }
       
        private IDbConnection GetConnection()
        {            
            _connection.Open();
            return _connection;
        }
    }
}