using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GakuGym.Client;
using GakuGym.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("body");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<HttpClient>(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IGakuGymAPI, GakuGymClient>();
builder.Services.AddScoped<IRouteMatcher, RouteMatcher>();

#if DEBUG_NO_AUTH
    builder.Services.AddSingleton<ISecurity, NoAuthSecurity>();
#else
    builder.Services.AddSingleton<ISecurity, Security>();
#endif

await builder.Build().RunAsync();
