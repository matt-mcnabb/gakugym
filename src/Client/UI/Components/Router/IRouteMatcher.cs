namespace GakuGym.Client;

using Microsoft.AspNetCore.Components;

public interface IRouteMatcher
{
    void       LoadRoutes();
    RouteData? MatchRoute(string uri);
}
