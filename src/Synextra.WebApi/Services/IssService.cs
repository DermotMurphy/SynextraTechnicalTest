using Newtonsoft.Json;
using Synextra.Domain;

namespace Synextra.WebApi.Services;

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

        var issMessage = JsonConvert.DeserializeObject<IssMessage>(response) ?? CreateFakeIssMessage();

        return issMessage;
    }

    private static IssMessage CreateFakeIssMessage()
    {
        var unixTimestamp = (int)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
        return new IssMessage { Message = "Missing", Timestamp = unixTimestamp };
    }
}