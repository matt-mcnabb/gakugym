﻿#pragma checksum "D:\Code\GakuGym\public\src\Client\UI\Pages\FactDatabaseSearch.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6927a2e3080f1b310502bb52c36cdc2d508e3c97073c7c127ce44f5911e998e4"
// <auto-generated/>
#pragma warning disable 1591
namespace GakuGym.Client.UI.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/fact-database/search")]
    public partial class FactDatabaseSearch : BaseComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "pageHeader");
            __builder.AddMarkupContent(2, "<span id=\"pageHeaderLeft\">Fact Database - Search</span>\n    ");
            __builder.OpenElement(3, "span");
            __builder.AddAttribute(4, "id", "pageHeaderRight");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "SecondaryButton");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\Code\GakuGym\public\src\Client\UI\Pages\FactDatabaseSearch.razor"
                                                                         OnBackClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(8, "<svg class=\"icon\"><use xlink:href=\"#back\"></use></svg>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "id", "pageBody");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "id", "factSearchBar");
            __builder.AddMarkupContent(14, "<input type=\"text\" placeholder=\"Enter a search query\">\n        ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "D:\Code\GakuGym\public\src\Client\UI\Pages\FactDatabaseSearch.razor"
                          OnSearchClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(17, "<svg class=\"icon\"><use xlink:href=\"#search\"></use></svg>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "D:\Code\GakuGym\public\src\Client\UI\Pages\FactDatabaseSearch.razor"
 
    string         searchInputText = "";
    SearchResults? searchResults;

    SearchQuery ParseQuery(string text)
    {
        return new SearchQuery
        {
            
        };
    }

    void OnBackClick()
    {
        NavigationManager.NavigateTo("/fact-database");   
    }

    async Task Search()
    {
        var results = await API.SearchFacts(ParseQuery(searchInputText));
    }

    async Task OnSearchClick()
    {
        
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
