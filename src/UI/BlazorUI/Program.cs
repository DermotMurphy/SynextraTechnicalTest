using BlazorUI.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorUI;

public class Program
{
    private const string WebApiUrl = @"https://localhost:44316";

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");

        builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<IissService, IssService>();

        await builder.Build().RunAsync();
    }
}