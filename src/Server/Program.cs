using GakuGym.Server;
using GakuGym.Common;

await DB.Init($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gym.db")}");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<Settings>();
#if NO_AUTH
    builder.Services.AddSingleton<NoAuthSecurity>();
#else
    builder.Services.AddSingleton<Security>();
#endif
builder.Services.AddSingleton<IGakuGymAPI, GakuGymAPI>();
builder.Services.AddSingleton<Endpoints>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
    app.UseExceptionHandler("/Error");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseEndpoints(app.Services.GetService<Endpoints>()!.MapEndpoints);

app.Run();
