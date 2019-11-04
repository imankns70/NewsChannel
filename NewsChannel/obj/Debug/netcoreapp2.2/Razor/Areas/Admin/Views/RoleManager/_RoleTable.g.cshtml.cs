#pragma checksum "E:\project\NewsChannel\NewsChannel\Areas\Admin\Views\RoleManager\_RoleTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbd4b383e5b4b494bb08db15cccda56c0c5bff79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_RoleManager__RoleTable), @"mvc.1.0.view", @"/Areas/Admin/Views/RoleManager/_RoleTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/RoleManager/_RoleTable.cshtml", typeof(AspNetCore.Areas_Admin_Views_RoleManager__RoleTable))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbd4b383e5b4b494bb08db15cccda56c0c5bff79", @"/Areas/Admin/Views/RoleManager/_RoleTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_RoleManager__RoleTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 107, true);
            WriteLiteral("\r\n<div id=\"toolbar\">\r\n    <button type=\"button\" class=\"btn btn-success\" data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(108, 38, false);
#line 3 "E:\project\NewsChannel\NewsChannel\Areas\Admin\Views\RoleManager\_RoleTable.cshtml"
                                                                                Write(Url.Action("RenderRole","RoleManager"));

#line default
#line hidden
            EndContext();
            BeginContext(146, 157, true);
            WriteLiteral("\">\r\n        <i class=\"fa fa-plus\"></i> | افزودن نقش جدید\r\n    </button>\r\n    <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(304, 32, false);
#line 6 "E:\project\NewsChannel\NewsChannel\Areas\Admin\Views\RoleManager\_RoleTable.cshtml"
                                                                               Write(Url.Action("DeleteGroup","Base"));

#line default
#line hidden
            EndContext();
            BeginContext(336, 1816, true);
            WriteLiteral(@""">
        <i class=""fa fa-trash""></i> | حذف گروهی
    </button>
</div>
<table id=""table""
       data-toolbar=""#toolbar""
       data-search=""true""
       data-show-refresh=""true""
       data-show-toggle=""true""
       data-show-fullscreen=""true""
       data-show-columns=""true""
       data-detail-view=""true""
       data-show-export=""true""
       data-click-to-select=""true""
       data-detail-formatter=""detailFormatter""
       data-minimum-count-columns=""2""
       data-show-pagination-switch=""true""
       data-pagination=""true""
       data-id-field=""id""
       data-page-list=""[10, 25, 50, 100, all]""
       data-show-footer=""true""
       data-side-pagination=""server""
       data-url=""/Admin/RoleManager/GetRoles""
       data-response-handler=""responseHandler""></table>


<script>
    var $table = $('#table');
        var selections = [];


  function get_query_params(p) {
    return {
        extraParam: 'abc',
        search: p.title,
        sort: p.sort,
        order: p.order");
            WriteLiteral(@",
        limit: p.limit,
        offset: p.offset
    }
}


        function responseHandler(res) {
            $.each(res.rows, function (i, row) {
                row.state = $.inArray(row.id, selections) !== -1;
            })
            return res;
        }

         function detailFormatter(index, row) {
            var html = []
            $.each(row, function (key, value) {
                if (key != ""state"" && key != ""Id"" && key != ""ردیف"")
                    html.push('<p><b>' + key + ':</b> ' + value + '</p>');
            })
             return html.join('');
         }


         function operateFormatter(value, row, index) {
        return [
            '<button type=""button"" class=""btn-link text-success"" data-toggle=""ajax-modal"" data-url=");
            EndContext();
            BeginContext(2153, 39, false);
#line 68 "E:\project\NewsChannel\NewsChannel\Areas\Admin\Views\RoleManager\_RoleTable.cshtml"
                                                                                              Write(Url.Action("RenderRole", "RoleManager"));

#line default
#line hidden
            EndContext();
            BeginContext(2192, 212, true);
            WriteLiteral("?roleId=\' + row.Id + \' title=\"ویرایش\">\',\r\n            \'<i class=\"fa fa-edit\"></i>\',\r\n            \'</button >\',\r\n\r\n            \'<button type=\"button\" class=\"btn-link text-danger\" data-toggle=\"ajax-modal\" data-url=");
            EndContext();
            BeginContext(2405, 35, false);
#line 72 "E:\project\NewsChannel\NewsChannel\Areas\Admin\Views\RoleManager\_RoleTable.cshtml"
                                                                                             Write(Url.Action("Delete", "RoleManager"));

#line default
#line hidden
            EndContext();
            BeginContext(2440, 2269, true);
            WriteLiteral(@"/?roleId=' + row.Id + ' title=""حذف"">',
            '<i class=""fa fa-trash""></i>',
            '</button >'
        ].join('')
    }

     function checkBoxFormat(value, row) {
       return '<input type=""checkbox"" name=""btSelectItem"" value=""' + row.Id + '"" />';
    }


        function totalTextFormatter(data) {
            return 'تعداد'
        }

        function totalNameFormatter(data) {
            return data.length
        }


        function initTable() {
            $table.bootstrapTable('destroy').bootstrapTable({
                height: 600,
                locale: 'fa-IR',
                columns: [
                    [{
                        field: 'state',
                        checkbox: true,
                        rowspan: 2,
                        align: 'center',
                        valign: 'middle',
                        formatter: checkBoxFormat
                    }, {
                        title: 'ردیف',
                        field: 'ر");
            WriteLiteral(@"دیف',
                        rowspan: 2,
                        align: 'center',
                        valign: 'middle',
                        footerFormatter: totalTextFormatter
                    }, {
                        title: 'جزئیات اطلاعات نقش ها',
                        colspan: 3,
                        align: 'center'
                    }],
                    [{
                        field: 'عنوان نقش',
                        title: 'عنوان نقش',
                        sortable: true,
                        footerFormatter: totalNameFormatter,
                        align: 'center'
                    }, {
                        field: 'تعداد کاربران',
                        title: 'تعداد کاربران',
                        align: 'center'
                    }, {
                        field: 'operate',
                        title: 'عملیات',
                        align: 'center',
                        events: window.operateEvents,
                 ");
            WriteLiteral("       formatter: operateFormatter\r\n                    }]\r\n                ]\r\n            })\r\n        }\r\n\r\n        $(function () {\r\n            initTable()\r\n            $(\'#locale\').change(initTable)\r\n        })</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
