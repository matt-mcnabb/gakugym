namespace GakuGym.Server;

using GakuGym.Common;

internal class Settings
{
    public string SecurityPasswordHash => GetString(nameof(SecurityPasswordHash));
    public string SecurityTokenSecret  => GetString(nameof(SecurityTokenSecret));

    private Dictionary<string, string>? settings;

    private string GetString(string settingName) => settings![settingName];

    public Settings()
    {
        settings = JSON.Deserialize<Dictionary<string, string>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json")));
    }
}
