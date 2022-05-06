﻿#pragma checksum "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e2483a83b601ae9d52d9c83bea5a6ea110ec13b71f3049e7bf504e430ab119e7"
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
#nullable restore
#line 3 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fact-database/domain/{RouteParamDomainId:guid}/edit")]
    public partial class DomainEdit : BaseComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
 if(domain != null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "pageHeader");
            __builder.OpenElement(2, "span");
            __builder.AddAttribute(3, "id", "pageHeaderLeft");
            __builder.AddContent(4, "Edit Domain - ");
#nullable restore
#line (8,44)-(8,55) 24 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
__builder.AddContent(5, domain.name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\n\t\t");
            __builder.OpenElement(7, "span");
            __builder.AddAttribute(8, "id", "pageHeaderRight");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "SecondaryButton");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
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
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(16);
            __builder.AddAttribute(17, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 12 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
                         this

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
                                              OnSaveClick

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(20);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\n\t\t\t");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "class", "inputWrapper");
                __builder2.AddMarkupContent(24, "<label>Name</label>\n\t\t\t\t");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(25);
                __builder2.AddAttribute(26, "placeholder", "Name of the domain");
                __builder2.AddAttribute(27, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
                                        this.nameText

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => this.nameText = __value, this.nameText))));
                __builder2.AddAttribute(29, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => this.nameText));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\n\t\t\t\t");
                __Blazor.GakuGym.Client.UI.Pages.DomainEdit.TypeInference.CreateValidationMessage_0(__builder2, 31, 32, 
#nullable restore
#line 17 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
                                        () => this.nameText

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\n\t\t\t");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "inputWrapper");
                __builder2.AddMarkupContent(36, "<label>Description</label>\n\t\t\t\t");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(37);
                __builder2.AddAttribute(38, "placeholder", "A description (optional)");
                __builder2.AddAttribute(39, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
                                        this.descriptionText

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => this.descriptionText = __value, this.descriptionText))));
                __builder2.AddAttribute(41, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => this.descriptionText));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\n\t\t\t");
                __builder2.AddMarkupContent(43, "<button type=\"submit\">Save</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 26 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "D:\Code\GakuGym\public\src\Client\UI\Pages\DomainEdit.razor"
 
	[Parameter]
	public Guid RouteParamDomainId { get; set; }

	Domain? domain;

	[Required]
	public string? nameText { get; set; }
	public string? descriptionText;

	protected override async Task OnParametersSetAsync()
	{
		domain = await API.GetDomain(RouteParamDomainId);

		nameText        = domain.name;
		descriptionText = domain.description;
	}

	void OnCloseClick()
	{
		NavigationManager.NavigateTo($"/fact-database/domain/{RouteParamDomainId}");
	}

	async Task OnSaveClick()
	{
		await API.UpdateDomain(new Domain
		{
			guid = domain.guid,
			name = nameText,
			description = descriptionText
		});

		NavigationManager.NavigateTo($"/fact-database/domain/{RouteParamDomainId}");
	}

#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.GakuGym.Client.UI.Pages.DomainEdit
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
