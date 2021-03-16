using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebUserManagement.Api.DAL.Models;
using System.Transactions;

namespace WebUserManagement.Api.DAL
{
    public class UserRepository : IRepository
    {
        private class StoredProcedureDefinitionAndParameters
        {
            public StoredProcedureDefinitionAndParameters(string storedProcedureName, object value)
            {
                StoreProcedureName = storedProcedureName;
                Value = value;
            }
            public string StoreProcedureName { get; }
            public object Value { get; }
        }

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

        public async Task<bool> DeleteAsync(long id)
        {
            return await ExecuteStoredProcedureInTransaction(id, new StoredProcedureDefinitionAndParameters("DeleteUser", new { Id = id }));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            return await ExecuteStoredProcedureInTransaction(user.Id, new StoredProcedureDefinitionAndParameters("UpdateUser", user));
        }

        private async Task<bool> ExecuteStoredProcedureInTransaction(long userId, StoredProcedureDefinitionAndParameters command)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = GetConnection())
            {

                if (!await CheckIfUserExists(userId, connection))
                    return false;

                await connection.ExecuteScalarAsync(command.StoreProcedureName, command.Value, commandType: CommandType.StoredProcedure);
                scope.Complete();
                return true;
            }
        }


        private async Task<bool> CheckIfUserExists(long id, IDbConnection connection)
        {
            return (await connection.QueryAsync<User>("GetUserById", new { Id = id }, commandType: CommandType.StoredProcedure)).Any();
        }

        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}