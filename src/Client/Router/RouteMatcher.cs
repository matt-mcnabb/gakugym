namespace GakuGym.Client;

using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

public class RouteMatcher : IRouteMatcher
{
    private record Route(Type component, Regex regex, Dictionary<string, Type> parameters);

    private List<Route> routes = new List<Route>();

    public void LoadRoutes()
    {
        var routableComponents = typeof(AppRouter).Assembly.GetExportedTypes().Where(x => x.IsDefined(typeof(RouteAttribute), true) && typeof(IComponent).IsAssignableFrom(x));

        routes = routableComponents.Select(componentType =>
        {
            var template = componentType.GetCustomAttributes(typeof(RouteAttribute), true).Cast<RouteAttribute>().Single().Template;

            var templateParts = template.Split('/');

            var regex = "^";
            var parameters = new Dictionary<string, Type>();

            foreach (var part in templateParts)
            {
                if(regex != "^")
                    regex += "/";

                if (part.StartsWith("{") && part.EndsWith("}"))
                {
                    var paramParts = part.Substring(1, part.Length - 2).Split(':');

                    regex += $"(?<{paramParts[0]}>.*?)";

                    parameters.Add(paramParts[0], (paramParts.Length == 2 ? paramParts[1] : "string") switch
                    {
                        "string" => typeof(string),
                        "guid"   => typeof(Guid),
                        _        => throw new Exception($"Unsupported route parameter type '{paramParts[1]}'") 
                    });
                }
                else
                {
                    regex += Regex.Escape(part);
                }
            }

            regex += "$";

            return new Route(componentType, new Regex(regex), parameters);
        }).ToList();
    }

    public RouteData? MatchRoute(string uri)
    {
        foreach(var route in routes)
        {
            var match = route.regex.Match(uri);

            if(match.Success)
            {
                return new RouteData(route.component, route.parameters.ToDictionary(x => x.Key, x => x.Value switch
                {
                    Type t when t == typeof(string) => (object)match.Groups[x.Key].Value,
                    Type t when t == typeof(Guid)   => (object)Guid.Parse(match.Groups[x.Key].Value),
                    _                               => throw new InvalidOperationException("Unreachable.")
                }));
            }
        }

        return null;
    }
}
