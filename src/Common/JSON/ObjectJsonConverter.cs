namespace GakuGym.Common;

using System.Text.Json;
using System.Text.Json.Serialization;

internal class ObjectJsonConverter : JsonConverter<object>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(object);
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerCopy = reader;

        if (reader.TokenType == JsonTokenType.True)
            return true;

        if (reader.TokenType == JsonTokenType.False)
            return false;

        if (reader.TokenType == JsonTokenType.String)
            return reader.GetString();

        if (readerCopy.TokenType != JsonTokenType.StartObject)
            goto DEFAULT_SERIALIZE;

        readerCopy.Read();

        if (readerCopy.TokenType != JsonTokenType.PropertyName)
            goto DEFAULT_SERIALIZE;

        readerCopy.Read();

        if (readerCopy.TokenType != JsonTokenType.String)
            goto DEFAULT_SERIALIZE;

        var type = readerCopy.GetString();

        if (type == "byte[]")
            return JsonSerializer.Deserialize(ref reader, typeof(byte[]), options);

        DEFAULT_SERIALIZE:
            return JsonSerializer.Deserialize(ref reader, typeToConvert);
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
