namespace GakuGym.Client;

using GakuGym.Common;
using Microsoft.AspNetCore.Components;

public class BaseComponent : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
    [Inject] protected IGakuGymAPI       API               { get; set; } = default!;
}
