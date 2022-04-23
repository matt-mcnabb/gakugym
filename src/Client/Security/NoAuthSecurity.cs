namespace GakuGym.Client;

internal class NoAuthSecurity : ISecurity
{
    public string? AuthToken { get; private set; }

    public void SetAuthToken(string token)
    {
        AuthToken = token;
    }

    public bool IsAuthenticated()
    {
        return true;
    }
}
