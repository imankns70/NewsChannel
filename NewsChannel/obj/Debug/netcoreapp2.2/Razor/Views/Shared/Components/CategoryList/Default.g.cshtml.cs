#pragma checksum "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2a919abe12cf15b4c52b75e92e87eb1f78570f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoryList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CategoryList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CategoryList_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2a919abe12cf15b4c52b75e92e87eb1f78570f1", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoryList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NewsChannel.ViewModel.Category.TreeViewCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(62, 64, true);
            WriteLiteral("\r\n<div class=\"classynav\">\r\n    <ul>\r\n        <li class=\"active\">");
            EndContext();
            BeginContext(126, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2a919abe12cf15b4c52b75e92e87eb1f78570f13776", async() => {
                BeginContext(170, 4, true);
                WriteLiteral("خانه");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(178, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 6 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
         foreach (var item in Model.OrderBy(t=>t.Title))
        {

#line default
#line hidden
            BeginContext(254, 36, true);
            WriteLiteral("            <li>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 290, "\"", 316, 4);
            WriteAttributeValue("", 297, "/", 297, 1, true);
#line 9 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 298, item.Id, 298, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 306, "/", 306, 1, true);
#line 9 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 307, item.Url, 307, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(317, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(319, 10, false);
#line 9 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                                         Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(329, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 10 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                 if (item.Subs.Count() != 0)
                {

#line default
#line hidden
            BeginContext(400, 43, true);
            WriteLiteral("                    <ul class=\"dropdown\">\r\n");
            EndContext();
#line 13 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                         foreach (var sub in item.Subs)
                        {

#line default
#line hidden
            BeginContext(527, 34, true);
            WriteLiteral("                            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 561, "\"", 585, 4);
            WriteAttributeValue("", 568, "/", 568, 1, true);
#line 15 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 569, sub.Id, 569, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 576, "/", 576, 1, true);
#line 15 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 577, sub.Url, 577, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(586, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(588, 9, false);
#line 15 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                                                       Write(sub.Title);

#line default
#line hidden
            EndContext();
            BeginContext(597, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 16 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(635, 29, true);
            WriteLiteral("\r\n                    </ul>\r\n");
            EndContext();
#line 19 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(683, 21, true);
            WriteLiteral("\r\n            </li>\r\n");
            EndContext();
#line 22 "D:\projects\NewsChannel\NewsChannel\Views\Shared\Components\CategoryList\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(715, 72, true);
            WriteLiteral("\r\n        <li><a href=\"contact.html\">ویدیوها</a></li>\r\n    </ul>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NewsChannel.ViewModel.Category.TreeViewCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
