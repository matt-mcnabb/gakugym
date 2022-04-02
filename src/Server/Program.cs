using GakuGym.Server;

Settings.Init();
Security.Initialize();

await DB.Init($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gym.db")}");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.UseEndpoints(GakuGym.Server.Endpoints.MapEndpoints);

app.Run();
