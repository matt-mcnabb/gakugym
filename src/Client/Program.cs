using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GakuGym.Client;
using GakuGym.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("body");
builder.RootComponents.Add<HeadOutlet>("head::after");

Globals.httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

builder.Services.AddSingleton<IGakuGymAPI, GakuGymClient>();
builder.Services.AddScoped<IRouteMatcher, RouteMatcher>();

await builder.Build().RunAsync();

public static class Globals
{
    public static HttpClient httpClient;
}
