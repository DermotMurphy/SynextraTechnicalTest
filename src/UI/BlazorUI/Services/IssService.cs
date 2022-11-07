using System.Text.Json;

namespace BlazorUI.Services;

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

        var message = JsonSerializer.Deserialize<IssMessageDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ??
                      CreateFakeIssMessageDto();

        return message;
    }

    private IssMessageDto CreateFakeIssMessageDto()
    {
        return new IssMessageDto { Message = "Missing", LocalTime = DateTime.Now };
    }
}