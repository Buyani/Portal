#pragma checksum "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a085278c7f1303c0a21486a0356b8f02a4763ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Users), @"mvc.1.0.view", @"/Views/Admin/Users.cshtml")]
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
#line 1 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\_ViewImports.cshtml"
using Portal.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\_ViewImports.cshtml"
using Portal.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a085278c7f1303c0a21486a0356b8f02a4763ea", @"/Views/Admin/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1abeb2a4285512920e61e5be467a74c606a1f438", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Portal.Model.UserModels.ViewModels.UserViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
  
    ViewData["Title"] = "Users";
    Layout = "~/Views/Shared/_Administrator.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-md-12"">
    <div class=""card"">
        <div class=""card-header card-header-primary"">
            <h4 class=""card-title "">Users List</h4>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table"">
                    <thead class="" text-primary"">
                    <th>
                        FirstName
                    </th>
                    <th>
                        LastName
                    </th>
                    <th>
                        Eamil
                    </th>
                    <th>
                        Roles
                    </th>
                    <tbody>
                    <tbody>
");
#nullable restore
#line 30 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 34 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 37 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 40 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 42 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                           Write(string.Join(" , ", item.UserRoles.ToList()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n");
#nullable restore
#line 44 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                 if (item.Blocked)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"text-danger\">blocked</p>\r\n");
#nullable restore
#line 47 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"text-success\">active</p>\r\n");
#nullable restore
#line 51 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n                            <td>\r\n\r\n\r\n");
#nullable restore
#line 57 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                 if (item.Blocked)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2091, "\"", 2155, 1);
#nullable restore
#line 59 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
WriteAttributeValue("", 2098, Url.Action("Unblock", "Admin", new { userId = item.Id }), 2098, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"material-icons icon-red\">toggle_off</span></a>\r\n");
#nullable restore
#line 60 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                }
                                else
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2366, "\"", 2428, 1);
#nullable restore
#line 64 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
WriteAttributeValue("", 2373, Url.Action("Block", "Admin", new { userId = item.Id }), 2373, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"material-icons icon-blue\">toggle_on</span></a>\r\n");
#nullable restore
#line 65 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 69 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                 if (!item.Blocked)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2723, "\"", 2782, 1);
#nullable restore
#line 71 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
WriteAttributeValue(" ", 2730, Url.Action("Manage","Admin",new {userId=item.Id }), 2731, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"material-icons\">edit</span></a>\r\n");
#nullable restore
#line 72 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 76 "C:\Users\Admin\Source\repos\Portal\src\Portal.WebUI\Portal.WebUI\Views\Admin\Users.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n            <p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a085278c7f1303c0a21486a0356b8f02a4763ea10780", async() => {
                WriteLiteral("<span class=\"material-icons\">person_add</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n<style>\r\n    span.icon-blue {\r\n        color: blue;\r\n    }\r\n\r\n    span.icon-red {\r\n        color: red;\r\n    }\r\n</style>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Portal.Model.UserModels.ViewModels.UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
