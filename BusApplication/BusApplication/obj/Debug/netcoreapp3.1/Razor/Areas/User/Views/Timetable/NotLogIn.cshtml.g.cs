#pragma checksum "C:\GIT\BusApplication\BusApplication\BusApplication\Areas\User\Views\Timetable\NotLogIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c736683e36a0adf68e68ff0879f7146adbb5394"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Timetable_NotLogIn), @"mvc.1.0.view", @"/Areas/User/Views/Timetable/NotLogIn.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\GIT\BusApplication\BusApplication\BusApplication\Areas\User\Views\_ViewImports.cshtml"
using BusApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GIT\BusApplication\BusApplication\BusApplication\Areas\User\Views\_ViewImports.cshtml"
using BusApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c736683e36a0adf68e68ff0879f7146adbb5394", @"/Areas/User/Views/Timetable/NotLogIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f60c4eb09d066185134f7e8d690ae926b53ba00a", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Timetable_NotLogIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\GIT\BusApplication\BusApplication\BusApplication\Areas\User\Views\Timetable\NotLogIn.cshtml"
  
    ViewData["Title"] = "Nie zalogowany";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container"">
    <div class=""row bg-dark text-white p-3 m-3"">
        <div class=""alert alert-dismissible alert-danger col-12 text-center "">
            <br />
            <strong>Aby zakupić bilet musisz być zalogowany!</strong> 
            <br />
            <a href=""/Identity/Account/Login"" class=""alert-link""><i>Zaloguj się</i></a> i spróbuj ponownie.
            <br />
            <br />
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
