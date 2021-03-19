using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.Api.DAL
{
    /// <summary>
    /// IDbConnection and IRepository are injected as in request scope. It means the explicit Dispose is not necessary. 
    /// Ninject should dispose it by itself
    /// </summary>
    public class UserRepository : IRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<long> CreateAsync(User user)
        {
            return await GetConnection().ExecuteScalarAsync<long>("AddUser",
                            new { LastName = user.LastName, FirstName = user.FirstName, Email = user.Email },
                            commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(long id)
        {
            await GetConnection().ExecuteScalarAsync("DeleteUser", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await GetConnection().QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(User user)
        {
            await GetConnection().ExecuteScalarAsync("UpdateUser", user, commandType: CommandType.StoredProcedure);
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return (await GetConnection().QueryAsync<User>("GetUserById", new { Id = id }, commandType: CommandType.StoredProcedure))
                .FirstOrDefault();
        }

        private IDbConnection GetConnection()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            return _connection;
        }
    }
}