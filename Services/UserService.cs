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
    }
}
