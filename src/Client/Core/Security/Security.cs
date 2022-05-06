namespace GakuGym.Client;

internal class Security : ISecurity
{
    public string? AuthToken { get; private set; }

    public void SetAuthToken(string token)
    {
        AuthToken = token; 
    }

    public bool IsAuthenticated()
    {
        return AuthToken != null;
    }
}
