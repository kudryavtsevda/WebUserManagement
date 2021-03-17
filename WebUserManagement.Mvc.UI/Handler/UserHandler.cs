using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebUserManagement.DTO;
using System.Net.Http.Json;

namespace WebUserManagement.Mvc.UI.Handler
{
    public class UserHandler : IUserHandler
    {
        private static readonly HttpClient _httpClient;
        static UserHandler()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:44397/api/users") };
        }
        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            var res = await _httpClient.PostAsJsonAsync("", request);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<long>();
        }

        public async Task<long> DeleteAsync(long id)
        {
            var res = await _httpClient.DeleteAsync($"/api/users/{id}");
            res.EnsureSuccessStatusCode();
            return id;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserResponse>>("");
        }

        public async Task<UserResponse> GetByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<UserResponse>($"/api/users/{id}");
        }

        public async Task<long> UpdateAsync(long id, UpdateUserRequest request)
        {
            var res = await _httpClient.PutAsJsonAsync($"/api/users/{id}", request);
            res.EnsureSuccessStatusCode();
            return id;
        }
    }
}