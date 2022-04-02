﻿#pragma checksum "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "fb0218c80e052f340cc245c2284560bfef52145cf5da9efb1938418b6de6129d"
// <auto-generated/>
#pragma warning disable 1591
namespace GakuGym.Client.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/fact-database/category/{RouteCategoryId:guid}/add-fact")]
    public partial class AddFact : BaseComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
 if(category != null && fieldValues != null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "pageHeader");
            __builder.OpenElement(2, "span");
            __builder.AddAttribute(3, "id", "pageHeaderLeft");
#nullable restore
#line (7,33)-(7,46) 24 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
__builder.AddContent(4, category.name);

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, " - New Fact");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\n\t\t");
            __builder.OpenElement(7, "span");
            __builder.AddAttribute(8, "id", "pageHeaderRight");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "SecondaryButton");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
                                                      OnCloseClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(12, "<svg class=\"icon\"><use xlink:href=\"#close\"></use></svg>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n\t");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "id", "pageBody");
#nullable restore
#line 14 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
         foreach(var field in fieldValues)
		{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "inputWrapper");
            __builder.OpenElement(18, "label");
#nullable restore
#line (17,13)-(17,28) 25 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
__builder.AddContent(19, field.fieldName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n\t\t\t\t");
            __builder.OpenElement(21, "input");
            __builder.AddAttribute(22, "type", "text");
            __builder.AddAttribute(23, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
                                                 field.value

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => field.value = __value, field.value));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 20 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(25, "div");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
                              OnAddFactClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(28, "Create Fact");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 25 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "D:\Code\GakuGym\public\src\Client\Pages\AddFact.razor"
 
	[Parameter]
	public Guid RouteCategoryId { get; set; }

	Category? category;

	class FactFieldModel
	{
		public Guid    guid;
		public string? fieldName;
		public string? value;
	}

	List<FactFieldModel>? fieldValues;

	protected override async Task OnParametersSetAsync()
	{
		category = await API.GetCategory(RouteCategoryId);

		fieldValues = category.fields.Select(x => new FactFieldModel { guid = x.guid, fieldName = x.name, value = "" }).ToList();		
	}

	void OnCloseClick()
	{
		NavigationManager.NavigateTo($"/fact-database/category/{RouteCategoryId}");		
	}

	async Task OnAddFactClick()
	{
		await API.AddFact(category.guid, fieldValues.ToDictionary(x => x.guid, x => x.value));

		NavigationManager.NavigateTo($"/fact-database/category/{category.guid}");
	}


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
