namespace GakuGym.Client;

internal static class Security
{
    public static string? AuthToken { get; private set; }

    public static void SetAuthToken(string token)
    {
        AuthToken = token; 
    }

    public static bool IsAuthenticated()
    {
        return AuthToken != null;
    }
}
