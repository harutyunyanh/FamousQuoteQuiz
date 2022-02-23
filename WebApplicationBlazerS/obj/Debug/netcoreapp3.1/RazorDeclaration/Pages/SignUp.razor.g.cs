// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebApplicationBlazerS.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using WebApplicationBlazerS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\_Imports.razor"
using WebApplicationBlazerS.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
using WebApplicationBlazerS.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
using RequestLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
using CommonLibrary.DBModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
using CommonLibrary.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
using HttpMethod = CommonLibrary.Models.HttpMethod;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(EmptyLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/SignUp")]
    public partial class SignUp : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "D:\Gits\FamousQuoteQuiz\WebApplicationBlazerS\Pages\SignUp.razor"
       
    private string nameValue { get; set; }
    private string snameValue { get; set; }
    private string loginValue { get; set; }
    private string passValue { get; set; }

    private void BackBtn()
    {
        NavManager.NavigateTo("/");
    }

    private void SignUpBtn()
    {
        var result = RequestManager.MakeInternal<LoginResponse>(
              method: HttpMethod.POST,
              body: new SignModel() { Name = nameValue,SurName = snameValue,Login = loginValue, Password = passValue },
              url: $"{ServicesConfigurator.GatewayWebServiceURL}Account/client/signup"
          );

        if (result.IsSuccessful())
        {
            NavManager.NavigateTo("/old");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591