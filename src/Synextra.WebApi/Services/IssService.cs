using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Synextra.Domain;

namespace Synextra.WebApi.Services
{
    public class IssService: IIssService
    {
        private readonly HttpClient _httpClient;

        public IssService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://api.open-notify.org/");
            _httpClient = httpClient;
        }

        public async Task<IssMessage> GetMessageAsync()
        {
            const string path = "iss-now.json";
            var response = await _httpClient.GetStringAsync(path);

            IssMessage issMessage = JsonConvert.DeserializeObject<IssMessage>(response);

            return issMessage;
        }
    }
}
