#pragma checksum "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c77bbde59bc08fb979597bd43f65da44b5061310"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Staff_Views_Tickets_Details), @"mvc.1.0.view", @"/Areas/Staff/Views/Tickets/Details.cshtml")]
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
#line 1 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\_ViewImports.cshtml"
using BusApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\_ViewImports.cshtml"
using BusApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c77bbde59bc08fb979597bd43f65da44b5061310", @"/Areas/Staff/Views/Tickets/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f60c4eb09d066185134f7e8d690ae926b53ba00a", @"/Areas/Staff/Views/_ViewImports.cshtml")]
    public class Areas_Staff_Views_Tickets_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BusApplication.Models.Tickets>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "TicketId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CancelTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success form-control mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
  
    ViewData["Title"] = "Szczegóły biletu";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""text-white mt-3 text-center"">Szczegóły biletu</h1>

<div class=""container"">
    <div class=""row bg-dark text-white p-3 m-3"">
        <div class=""col-12"">
            <div class=""form-group row pt-3"">
                <div class=""col-5"">
                    <h4>Data zakupu biletu:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 18 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.PurchaseDates);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                </div>\n            </div>\n            <div class=\"form-group row pt-2\">\n                <div class=\"col-5\">\n                    <h4>Kupujący:</h4>\n                </div>\n                <div class=\"col-7\">\n                    <h4>");
#nullable restore
#line 26 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.ApplicationUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                    Write(Model.ApplicationUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                </div>
            </div>
            <div class=""form-group row pt-2"">
                <div class=""col-5"">
                    <h4>Data wyjazdu:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 34 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.BusRoute.RouteDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 34 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                 Write(Model.BusRoute.RouteDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 34 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                 Write(Model.BusRoute.RouteDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                </div>\n            </div>\n            <div class=\"form-group row pt-2\">\n                <div class=\"col-5\">\n                    <h4>Stacja początkowa:</h4>\n                </div>\n                <div class=\"col-7 mb-1\">\n");
#nullable restore
#line 42 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                     if (Model.Departure.Minute < 10)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4>");
#nullable restore
#line 44 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                       Write(Model.StartBusStopName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />Odjazd: ");
#nullable restore
#line 44 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                             Write(Model.Departure.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":<text>0</text>");
#nullable restore
#line 44 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                                 Write(Model.Departure.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 45 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4>");
#nullable restore
#line 48 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                       Write(Model.StartBusStopName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />Odjazd: ");
#nullable restore
#line 48 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                             Write(Model.Departure.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 48 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                   Write(Model.Departure.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 49 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n                <div class=\"col-5\">\n                    <h4>Stacja końcowa</h4>\n                </div>\n                <div class=\"col-7\">\n");
#nullable restore
#line 55 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                     if (Model.Arrival.Minute < 10)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4>");
#nullable restore
#line 57 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                       Write(Model.EndBusStopName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />Przyjazd: ");
#nullable restore
#line 57 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                             Write(Model.Arrival.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":<text>0</text>");
#nullable restore
#line 57 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                               Write(Model.Arrival.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 58 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4>");
#nullable restore
#line 61 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                       Write(Model.EndBusStopName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />Przyjazd: ");
#nullable restore
#line 61 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                             Write(Model.Arrival.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 61 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                 Write(Model.Arrival.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 62 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <div class=""form-group row pt-2"">
                <div class=""col-5"">
                    <h4>Liczba biletów normalnych:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 70 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.NumberOfRegularTickets);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" szt.</h4>
                </div>
            </div>
            <div class=""form-group row pt-3"">
                <div class=""col-5"">
                    <h4>Liczba biletów studenkich:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 78 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.NumberOfStudentsTickets);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" szt.</h4>
                </div>
            </div>
            <div class=""form-group row pt-3"">
                <div class=""col-5"">
                    <h4>Liczba dodatkowych bagaży:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 86 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.NumberOfExtraBaggages);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" szt.</h4>
                </div>
            </div>
            <div class=""form-group row pt-3"">
                <div class=""col-5"">
                    <h4>Wartość biletów:</h4>
                </div>
                <div class=""col-7"">
                    <h4>");
#nullable restore
#line 94 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                   Write(Model.Payment.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" zł</h4>\n                </div>\n            </div>\n            <div class=\"form-group row pt-3\">\n                <div class=\"col-5\">\n                    <h2>Status:</h2>\n                </div>\n                <div class=\"col-7\">\n");
#nullable restore
#line 102 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                     if (Model.Payment.Status == "New")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h2 style=\"color: red;\"><strong>Oczekujący na płatność</strong></h2>\n");
#nullable restore
#line 105 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                    }
                    else if (Model.Payment.Status == "Confirmed")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h2 style=\"color: green;\"><strong>Opłacony</strong></h2>\n                        <h2>Dnia: ");
#nullable restore
#line 109 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                             Write(Model.Payment.ConfirmationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n");
#nullable restore
#line 110 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                         if (Model.Payment.ApplicationUser != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h4>Zatwierdzony przez: ");
#nullable restore
#line 112 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                               Write(Model.Payment.ApplicationUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 112 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                                        Write(Model.Payment.ApplicationUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 113 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h4>Zatwierdzony przez: konto usunięte</h4>\n");
#nullable restore
#line 117 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                         
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h2 style=\"color: white;\"><strong>Anulowany</strong></h2>\n                        <h2>Dnia: ");
#nullable restore
#line 122 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                             Write(Model.Payment.CanceledDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n");
#nullable restore
#line 123 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                         if (Model.Payment.ApplicationUser != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h4>Przez: ");
#nullable restore
#line 125 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                  Write(Model.Payment.ApplicationUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 125 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                                                                           Write(Model.Payment.ApplicationUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 126 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h4>Przez: konto usunięte</h4>\n");
#nullable restore
#line 130 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 130 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n            </div>\n\n            <div class=\"col-12\">\n");
#nullable restore
#line 136 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                 if (Model.Payment.Status == "New")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-4\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c77bbde59bc08fb979597bd43f65da44b506131022996", async() => {
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c77bbde59bc08fb979597bd43f65da44b506131023281", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 140 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                            <button type=\"submit\" class=\"btn btn-primary form-control mt-3\">Zatwierdź bilet</button>\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n");
#nullable restore
#line 144 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                 if (Model.Payment.Status != "Canceled")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-4\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c77bbde59bc08fb979597bd43f65da44b506131027380", async() => {
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c77bbde59bc08fb979597bd43f65da44b506131027665", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 149 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                            <button type=\"submit\" class=\"btn btn-info form-control mt-3\">Anuluj bilet</button>\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n");
#nullable restore
#line 153 "C:\GIT\Bus-Web-Application\BusApplication\BusApplication\Areas\Staff\Views\Tickets\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-4\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c77bbde59bc08fb979597bd43f65da44b506131031495", async() => {
                WriteLiteral("Wróć do listy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </div>\n            </div>\n\n        </div>\n\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BusApplication.Models.Tickets> Html { get; private set; }
    }
}
#pragma warning restore 1591
