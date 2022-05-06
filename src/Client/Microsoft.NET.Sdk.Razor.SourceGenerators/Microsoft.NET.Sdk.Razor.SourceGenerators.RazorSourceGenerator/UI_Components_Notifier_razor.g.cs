﻿#pragma checksum "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e205ff72430d8867614b7d0d514caee9538a43c6ccb06ab4f6f0dfa89ede14da"
// <auto-generated/>
#pragma warning disable 1591
namespace GakuGym.Client
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using GakuGym.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Code\GakuGym\public\src\Client\_Imports.razor"
using GakuGym.Common;

#line default
#line hidden
#nullable disable
    public partial class Notifier : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "Notifier");
#nullable restore
#line 4 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
     foreach(var notification in Notifications.All)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", 
#nullable restore
#line 6 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
                      notification.type switch
        {
            NotificationType.Info  => "InfoNotification",
            NotificationType.Error => "ErrorNotification",
            _ => ""
        }

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(4, "svg");
            __builder.AddAttribute(5, "class", "icon");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
                                          () => CloseNotification(notification)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(7, "<use xlink:href=\"#close\"></use>");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n            ");
#nullable restore
#line (12,14)-(12,34) 24 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
__builder.AddContent(9, notification.message);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 14 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "D:\Code\GakuGym\public\src\Client\UI\Components\Notifier.razor"
 
    protected override void OnInitialized()
    {
        Notifications.OnNotificationsChange += StateHasChanged;
    }

    public void Dispose()
    {
        Notifications.OnNotificationsChange -= StateHasChanged;    
    }

    void CloseNotification(Notification notification)
    {
        Notifications.Close(notification);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591