#pragma checksum "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f644f6d4c26238e0af9299d09d8cf8a01cb38ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RandomVideosList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RandomVideosList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/RandomVideosList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_RandomVideosList_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f644f6d4c26238e0af9299d09d8cf8a01cb38ae", @"/Views/Shared/Components/RandomVideosList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RandomVideosList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NewsChannel.ViewModel.Video.VideoViewModel>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 142, true);
            WriteLiteral("<div class=\"col-12 col-sm-6 col-xl-3\">\r\n        <div class=\"footer-widget mb-70\">\r\n            <h6 class=\"widget-title\">ویدیوهای تصادفی</h6>\r\n");
            EndContext();
#line 5 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(257, 129, true);
            WriteLiteral("                <div class=\"single-blog-post d-flex\">\r\n                    <div class=\"post-thumbnail\">\r\n                        ");
            EndContext();
            BeginContext(386, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9f644f6d4c26238e0af9299d09d8cf8a01cb38ae3730", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 396, "~/posters/", 396, 10, true);
#line 9 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
AddHtmlAttributeValue("", 406, item.Poster, 406, 12, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 9 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
AddHtmlAttributeValue("", 425, item.Poster, 425, 12, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(439, 104, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"post-content\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 543, "\"", 571, 2);
            WriteAttributeValue("", 550, "/Videos/", 550, 8, true);
#line 12 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
WriteAttributeValue("", 558, item.VideoId, 558, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(572, 20, true);
            WriteLiteral(" class=\"post-title\">");
            EndContext();
            BeginContext(593, 10, false);
#line 12 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(603, 58, true);
            WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 15 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomVideosList\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(676, 24, true);
            WriteLiteral("\r\n        </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NewsChannel.ViewModel.Video.VideoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
