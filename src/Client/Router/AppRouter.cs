namespace GakuGym.Client;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

public class AppRouter : IComponent, IHandleAfterRender, IDisposable
{
    [Inject] private NavigationManager       NavigationManager      { get; set; } = default!;
    [Inject] private INavigationInterception NavigationInterception { get; set; } = default!;
    [Inject] private IRouteMatcher           RouteMatcher           { get; set; } = default!;

    [Parameter] public RenderFragment<RouteData>? Found    { get; set; }
    [Parameter] public RenderFragment?            NotFound { get; set; }

    private bool navInterceptionEnabled = false;
    private RenderHandle renderHandle;

    public void Attach(RenderHandle renderHandle)
    {
        this.renderHandle = renderHandle;

        NavigationManager.LocationChanged += OnLocationChanged;
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    public async Task OnAfterRenderAsync()
    {
        if (!navInterceptionEnabled)
        {
            navInterceptionEnabled = true;
            
            await NavigationInterception.EnableNavigationInterceptionAsync();
        }
    }

    public async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);        

        RouteMatcher.LoadRoutes();

        Render();

        await Task.CompletedTask;
    }
    
    private void OnLocationChanged(object? sender, LocationChangedEventArgs args)
    {
        Render();
    }
    
    private void Render()
    {
        var uri = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

        if (!Security.IsAuthenticated() && uri != "login")
        {
            NavigationManager.NavigateTo("/login");
            return;
        }

        var routeData = RouteMatcher.MatchRoute(uri);

        if(routeData != null && Found != null)
            renderHandle.Render(Found(routeData));
        else if(NotFound != null)
            renderHandle.Render(NotFound);
    }
}
