using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module08.Model;
using System.Net.Http.Json;

namespace Module08.Services
{
     public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost/pdc50/";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<User>>GetUserAsync()
        {
            var response = 
                await _httpClient.GetFromJsonAsync <List<User>>($"{BaseUrl}get_user.php");
            return response ?? new List<User>();
        }

        //Add user
        public async Task<string> AddUsersAsync(User user)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}add_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        //Update User
        public async Task<string>UpdateUsersAsync(User user)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}update_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        
        //Delete User
        public async Task<string> DeleteUsersAsync(int userId)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}delete_user.php", new { id = userId });
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}
