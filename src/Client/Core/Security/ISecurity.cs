namespace GakuGym.Client;

internal interface ISecurity
{
    string? AuthToken { get; }

    void SetAuthToken(string token);
    bool IsAuthenticated();
}
