namespace GakuGym.Client;

using GakuGym.Common;
using Microsoft.AspNetCore.Components;

internal partial class GakuGymClient : IGakuGymAPI
{
    private readonly HttpClient httpClient;
    private readonly ISecurity Security;

    public GakuGymClient(HttpClient httpClient, ISecurity security)
    {
        this.httpClient = httpClient;
        this.Security = security;
    }

    private async Task<HttpResponseMessage> PostContent(string uri, string? content = null)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);

        httpRequest.Content = new StringContent(content ?? "", System.Text.Encoding.UTF8, "application/json");

        if (!String.IsNullOrEmpty(Security.AuthToken))
            httpRequest.Headers.Add("Authorization", Security.AuthToken);

        return await httpClient.SendAsync(httpRequest);
    }

    private async Task<TResponse?> PostRequest<TResponse>(string uri)
    {
        var response = await PostContent(uri);

        return JSON.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
    }

    private async Task<TResponse?> PostRequest<TRequest, TResponse>(string uri, TRequest request)
    {
        var response = await PostContent(uri, JSON.Serialize(request));

        return JSON.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
    }

    private async Task PostRequestVoid<TRequest>(string uri, TRequest request)
    {
        await PostContent(uri, JSON.Serialize(request));
    }

    private async Task PostRequestVoid(string uri)
    {
        await PostContent(uri);
    }
}
