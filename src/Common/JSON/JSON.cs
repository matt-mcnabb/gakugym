namespace GakuGym.Common;

using System.Text.Json;

public static class JSON
{
    private static readonly JsonSerializerOptions options;

    static JSON()
    {
        options = new JsonSerializerOptions();
 
        options.IncludeFields = true;
        options.WriteIndented = true;

        options.Converters.Add(new ByteArrayJsonConverter());
        options.Converters.Add(new ObjectJsonConverter());
    }

    public static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value, options);
    }

    public static T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, options);
    }
}
