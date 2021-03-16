using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;
using System.Transactions;
using WebUserManagement.Api.Exceptions;

namespace WebUserManagement.Api.DAL
{
    public class UserRepository : IRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
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

        public async Task<long> DeleteAsync(long id)
        {
            using (var scope = new TransactionScope())
            using (var connection = GetConnection())
            {
                await CheckIfUserExists(id, connection);

                await connection.ExecuteScalarAsync("DeleteUser", id, commandType: CommandType.StoredProcedure);
                scope.Complete();

                return id;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<long> UpdateAsync(User user)
        {
            return await ExecuteQuery(user);
        }

        private async Task<long> ExecuteQuery(User user)
        {
            using (var scope = new TransactionScope())
            using (var connection = GetConnection())
            {

                await CheckIfUserExists(user.Id, connection);

                await connection.ExecuteScalarAsync("UpdateUser", user, commandType: CommandType.StoredProcedure);

                scope.Complete();
                return user.Id;
            }
        }

        private async Task CheckIfUserExists(long id, IDbConnection connection)
        {
            _ = (await connection.QueryAsync<User>("GetUserById", id, commandType: CommandType.StoredProcedure))
                                        .FirstOrDefault() ?? throw new NotFoundException($"User is not found with id {id}");
        }

        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}