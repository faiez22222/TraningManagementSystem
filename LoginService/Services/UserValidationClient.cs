using LoginService.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using LoginService.DataTransferObject;

namespace LoginService.Services
{
    public class UserValidationClient: IUserValidationClient
    {
        private readonly HttpClient _httpClient;
        public UserValidationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 
        public async Task<User> ValidateUser(string username , string password)
        {
            var loginmodel = new Login
            {
                username = username,
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(loginmodel), Encoding.UTF8, "application/json");

            var response =await  _httpClient.PostAsync("http://localhost:5062/api/User/validate", content);
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);

            return user;
        }
    }
}
