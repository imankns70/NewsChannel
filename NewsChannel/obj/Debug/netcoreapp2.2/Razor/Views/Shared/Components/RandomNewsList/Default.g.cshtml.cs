#pragma checksum "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7b93e84cb1bb376dc2f9cad9ec561abd41b91fe"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7b93e84cb1bb376dc2f9cad9ec561abd41b91fe", @"/Views/Shared/Components/RandomNewsList/Default.cshtml")]
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
            if (item != null)
            {

#line default
#line hidden
            BeginContext(285, 131, true);
            WriteLiteral("                <div class=\"single-blog-post d-flex\">\r\n                    <div class=\"post-thumbnail\">\r\n\r\n                        ");
            EndContext();
            BeginContext(416, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e7b93e84cb1bb376dc2f9cad9ec561abd41b91fe3749", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 426, "~/newsImage/", 426, 12, true);
#line 13 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 438, item.ImageName, 438, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 13 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 460, item.ImageName, 460, 15, false);

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
            BeginContext(477, 104, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"post-content\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 581, "\"", 613, 4);
            WriteAttributeValue("", 588, "/", 588, 1, true);
#line 16 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 589, item.NewsId, 589, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 601, "/", 601, 1, true);
#line 16 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 602, item.Title, 602, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(614, 20, true);
            WriteLiteral(" class=\"post-title\">");
            EndContext();
            BeginContext(635, 10, false);
#line 16 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
                                                                          Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(645, 58, true);
            WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 19 "E:\project\NewsChannel\NewsChannel\Views\Shared\Components\RandomNewsList\Default.cshtml"
            }
           
        }

#line default
#line hidden
            BeginContext(742, 24, true);
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
