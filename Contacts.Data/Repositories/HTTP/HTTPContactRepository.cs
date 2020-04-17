using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.HTTP
{
    public class HTTPContactRepository : IContactRepository
    {
        private const string URL_API_CONTACT = @"http://10.0.2.2:59082/";
        private const string URI_CONTACT = URL_API_CONTACT + "api/contacts";
        private const string APPLICATION_JSON = "application/json";

        private readonly HttpClient httpClient;

        public HTTPContactRepository()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APPLICATION_JSON));
        }

        public async Task<IEnumerable<Contact>> ReadAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(URI_CONTACT);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error -> {response.StatusCode}");

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(responseContent);
        }

        public async Task<Contact> ReadAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{URI_CONTACT}/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error -> {response.StatusCode}");

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Contact>(responseContent);
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            using (HttpContent content = new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, APPLICATION_JSON))
            using (HttpResponseMessage response = await httpClient.PostAsync(URI_CONTACT, content))
                    return response.IsSuccessStatusCode ? true : throw new Exception($"[{MethodBase.GetCurrentMethod().Name}] # Error {response.StatusCode} return from API");
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            using (HttpContent content = new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, APPLICATION_JSON))
            using (HttpResponseMessage response = await httpClient.PutAsync($"{URI_CONTACT}/{contact.Id}", content))
                return response.IsSuccessStatusCode ? true : throw new Exception($"[{MethodBase.GetCurrentMethod().Name}] # Error {response.StatusCode} return from API");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (HttpResponseMessage response = await httpClient.DeleteAsync($"{URI_CONTACT}/{id}"))
                return response.IsSuccessStatusCode ? true : throw new Exception($"[{MethodBase.GetCurrentMethod().Name}] # Error {response.StatusCode} return from API");
        }

    }
}
