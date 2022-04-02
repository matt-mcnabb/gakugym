namespace GakuGym.Common;

using System.Text.Json;
using System.Text.Json.Serialization;

internal class ByteArrayJsonConverter : JsonConverter<byte[]>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(byte[]);
    }

    public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.Read(); // {
        reader.Read(); // "$type" :
        reader.Read(); // "byte[]"
        reader.Read(); // "value" : 

        var b64 = reader.GetString();

        reader.Read(); // }

        if (b64 == null)
            return null;

        return Convert.FromBase64String(b64);
    }

    public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("$type");
        writer.WriteStringValue("byte[]");
        writer.WritePropertyName("value");
        writer.WriteStringValue(Convert.ToBase64String(value));
        writer.WriteEndObject();
    }
}
