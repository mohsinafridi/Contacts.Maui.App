using Contacts.Maui.Models;
using Newtonsoft.Json;
using System.Text;

namespace Contacts.Maui.Services
{
    public class ApiService
    {
        public static async Task<List<Models.Contact>> GetContacts()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/employee");

            return JsonConvert.DeserializeObject<List<Models.Contact>>(response);
        }


        public static async Task<bool> CreateConnection(ConnectionModel model)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.localApiUrl + "ConnectionBuild", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<string> Test()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync("http://172.21.112.1/test");

            return response;
        }
    }
}
