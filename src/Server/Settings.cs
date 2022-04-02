namespace GakuGym.Server;

using GakuGym.Common;

public static class Settings
{
    public static string SecurityPasswordHash => GetString(nameof(SecurityPasswordHash));
    public static string SecurityTokenSecret  => GetString(nameof(SecurityTokenSecret));

    private static Dictionary<string, string>? settings;

    private static string GetString(string settingName) => settings![settingName];

    public static void Init()
    {
        settings = JSON.Deserialize<Dictionary<string, string>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json")));
    }
}
