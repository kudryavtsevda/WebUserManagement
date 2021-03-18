using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUserManagement.DTO;
using System.Net.Http.Json;
using System.Configuration;

namespace WebUserManagement.Mvc.UI.Handler
{
    public class UserHandler : IUserHandler
    {
        private readonly HttpClient _httpClient;
        public UserHandler()
        {
            //simple web service url injection. I don't care about limited connection per server
            var baseUrl = ConfigurationManager.AppSettings.Get("ServiceUrl");
            _httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }
        public async Task<long> CreateAsync(CreateUserRequest request)
        {
            var res = await _httpClient.PostAsJsonAsync("", request);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<long>();
        }

        public async Task<long> DeleteAsync(long id)
        {
            var res = await _httpClient.DeleteAsync($"{id}");
            res.EnsureSuccessStatusCode();
            return id;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserResponse>>("");
        }

        public async Task<UserResponse> GetByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<UserResponse>($"{id}");
        }

        public async Task<long> UpdateAsync(long id, UpdateUserRequest request)
        {
            var res = await _httpClient.PutAsJsonAsync($"{id}", request);
            res.EnsureSuccessStatusCode();
            return id;
        }
    }
}