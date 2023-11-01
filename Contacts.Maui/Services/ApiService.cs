using Newtonsoft.Json;

namespace Contacts.Maui.Services
{
    internal class ApiService
    {
        public static async Task<List<Contact>> GetContacts()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/employee");

            return JsonConvert.DeserializeObject<List<Contact>>(response);
        }
    }
}
