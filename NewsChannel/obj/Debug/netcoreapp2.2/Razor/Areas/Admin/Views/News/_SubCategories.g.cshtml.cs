#pragma checksum "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14beb66455f4a16c589f0117845335571c1eedfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_News__SubCategories), @"mvc.1.0.view", @"/Areas/Admin/Views/News/_SubCategories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/News/_SubCategories.cshtml", typeof(AspNetCore.Areas_Admin_Views_News__SubCategories))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14beb66455f4a16c589f0117845335571c1eedfd", @"/Areas/Admin/Views/News/_SubCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_News__SubCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewsChannel.ViewModel.News.NewsCategoriesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 8, true);
            WriteLiteral("\r\n<ul>\r\n");
            EndContext();
#line 4 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
     foreach (var item in Model.Categories)
    {

#line default
#line hidden
            BeginContext(119, 10, true);
            WriteLiteral("    <li>\r\n");
            EndContext();
#line 7 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
         if (Model.CategoryId != null)
        {
            if (Model.CategoryId.Contains(item.Id))
            {

#line default
#line hidden
            BeginContext(248, 57, true);
            WriteLiteral("                <input type=\"checkbox\" name=\"CategoryIds\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 305, "\"", 321, 1);
#line 11 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
WriteAttributeValue("", 313, item.Id, 313, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(322, 12, true);
            WriteLiteral(" checked /> ");
            EndContext();
            BeginContext(335, 10, false);
#line 11 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                                 Write(item.Title);

#line default
#line hidden
            EndContext();
#line 11 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                                                 
            }
            else
            {

#line default
#line hidden
            BeginContext(395, 57, true);
            WriteLiteral("                <input type=\"checkbox\" name=\"CategoryIds\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 452, "\"", 468, 1);
#line 15 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
WriteAttributeValue("", 460, item.Id, 460, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(469, 4, true);
            WriteLiteral(" /> ");
            EndContext();
            BeginContext(474, 10, false);
#line 15 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                         Write(item.Title);

#line default
#line hidden
            EndContext();
#line 15 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                                         
            }
        }

        else
        {

#line default
#line hidden
            BeginContext(539, 53, true);
            WriteLiteral("            <input type=\"checkbox\" name=\"CategoryIds\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 592, "\"", 608, 1);
#line 21 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
WriteAttributeValue("", 600, item.Id, 600, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(609, 4, true);
            WriteLiteral(" /> ");
            EndContext();
            BeginContext(614, 10, false);
#line 21 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                     Write(item.Title);

#line default
#line hidden
            EndContext();
#line 21 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
                                                                                     
        }

#line default
#line hidden
            BeginContext(637, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 24 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
           Model.Categories = item.Subs;

#line default
#line hidden
            BeginContext(682, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(691, 48, false);
#line 25 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
   Write(await Html.PartialAsync("_SubCategories", Model));

#line default
#line hidden
            EndContext();
            BeginContext(739, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 27 "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\News\_SubCategories.cshtml"
    }

#line default
#line hidden
            BeginContext(759, 7, true);
            WriteLiteral("\r\n</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewsChannel.ViewModel.News.NewsCategoriesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591