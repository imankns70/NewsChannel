#pragma checksum "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff87c1685c21a750761d244b11b86c4873ce17c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RandomNewsList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RandomNewsList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/RandomNewsList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_RandomNewsList_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff87c1685c21a750761d244b11b86c4873ce17c1", @"/Views/Shared/Components/RandomNewsList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RandomNewsList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NewsChannel.ViewModel.News.NewsViewModel>>
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
            BeginContext(55, 135, true);
            WriteLiteral("\r\n<div class=\"col-12 col-sm-6 col-xl-3\">\r\n    <div class=\"footer-widget mb-70\">\r\n        <h6 class=\"widget-title\"> اخبار تصادفی </h6>\r\n");
            EndContext();
#line 6 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(239, 117, true);
            WriteLiteral("            <div class=\"single-blog-post d-flex\">\r\n                <div class=\"post-thumbnail\">\r\n                    ");
            EndContext();
            BeginContext(356, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ff87c1685c21a750761d244b11b86c4873ce17c13687", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 366, "~/newsImage/", 366, 12, true);
#line 10 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 378, item.ImageName, 378, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 10 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 400, item.ImageName, 400, 15, false);

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
            BeginContext(417, 92, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"post-content\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 509, "\"", 541, 4);
            WriteAttributeValue("", 516, "/", 516, 1, true);
#line 13 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 517, item.NewsId, 517, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 529, "/", 529, 1, true);
#line 13 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 530, item.Title, 530, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(542, 20, true);
            WriteLiteral(" class=\"post-title\">");
            EndContext();
            BeginContext(563, 10, false);
#line 13 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(573, 50, true);
            WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 16 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(634, 24, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NewsChannel.ViewModel.News.NewsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
