using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services
{
    public class IssService : IissService
    {
        private readonly HttpClient _client;

        public IssService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IssMessageDto> GetPosition()
        {
            var response = await _client.GetAsync("https://localhost:44316/IssLocation");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var message = JsonSerializer.Deserialize<IssMessageDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return message;
        }
    }
}