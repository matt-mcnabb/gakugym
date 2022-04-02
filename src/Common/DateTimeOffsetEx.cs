namespace GakuGym.Common;

using System.Globalization;

public static class DateTimeOffsetEx
{
    public static string ToISO8601(this DateTimeOffset d)
    {
        return d.ToString("s") + "Z";
    }

    public static DateTimeOffset FromISO8601(string s)
    {
        return DateTimeOffset.ParseExact(s, "yyyy-MM-dd'T'HH:mm:ssZ", CultureInfo.InvariantCulture);
    }

}
