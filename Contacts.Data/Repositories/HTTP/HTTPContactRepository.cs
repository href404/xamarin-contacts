using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.HTTP
{
    public class HTTPContactRepository : IContactRepository
    {
        private const string URL_API_CONTACTS = @"http://10.0.2.2:59082/";
        private const string URI_CONTACTS = URL_API_CONTACTS + "api/contacts";

        private readonly HttpClient httpClient;

        public HTTPContactRepository()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Contact>> ReadAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(URI_CONTACTS);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error -> {response.StatusCode}");

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(responseContent);
        }

        public async Task<Contact> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
