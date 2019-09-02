#pragma checksum "D:\projects\NewsChannel\NewsChannel\Areas\Admin\Views\Category\_CategoryTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bcf84091540292012abc58f0510402f4509338f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category__CategoryTable), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/_CategoryTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/_CategoryTable.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category__CategoryTable))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bcf84091540292012abc58f0510402f4509338f", @"/Areas/Admin/Views/Category/_CategoryTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category__CategoryTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3733, true);
            WriteLiteral(@"
<div id=""toolbar"">
    <a class=""btn btn-success text-white"">درج دسته بندی جدید</a>
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
       data-url=""/Admin/Category/GetCategories""
       data-response-handler=""responseHandler""></table>

<script>
    var $table = $('#table');
    var selections = [];

    function get_query_params(p) {
        return {
            extraParam: 'abc',
            search: p.title,
            sort:");
            WriteLiteral(@" p.sort,
            order: p.order,
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
        var html = [];
        $.each(row, function (key, value) {
            html.push('<p><b>' + key + ':</b> ' + value + '</p>');
        })
        return html.join('');
    }

    function operateFormatter(value, row, index) {
        return [
            '<a class=""like"" href=""javascript:void(0)"" title=""Like"">',
            '<i class=""fa fa-heart""></i>',
            '</a>  ',
            '<a class=""remove"" href=""javascript:void(0)"" title=""Remove"">',
            '<i class=""fa fa-trash""></i>',
            '</a>'
        ].join('');
    }


    function totalTextFormatter(data) {
        return 'تعداد';
    }

    function totalNameFormatter");
            WriteLiteral(@"(data) {
        return data.length;
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
                    valign: 'middle'
                }, {
                    title: 'ردیف',
                    field: 'ردیف',
                    rowspan: 2,
                    align: 'center',
                    valign: 'middle',
                    sortable: true,
                    footerFormatter: totalTextFormatter
                }, {
                    title: 'جزئیات اطلاعات دسته بندی ها',
                    colspan: 3,
                    align: 'center'
                }],
                [{
                    field: 'دسته',
                    title: 'دسته',
                    sortable: true,
     ");
            WriteLiteral(@"               footerFormatter: totalNameFormatter,
                    align: 'center'
                }, {
                    field: 'دسته پدر',
                    title: 'دسته پدر',
                    sortable: true,
                    align: 'center'
                }, {
                    field: 'operate',
                    title: 'عملیات',
                    align: 'center',
                    events: window.operateEvents,
                    formatter: operateFormatter
                }]
            ]
        })
    }

    $(function () {
        initTable();
        $('#locale').change(initTable);
    });
</script>");
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
