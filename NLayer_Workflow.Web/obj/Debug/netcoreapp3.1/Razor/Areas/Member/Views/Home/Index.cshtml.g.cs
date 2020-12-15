#pragma checksum "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38fe7e1f84ee1c5c5fa3b6c7cbcc6f6d2613d6b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Member/Views/Home/Index.cshtml")]
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
#line 2 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Web.Areas.Member;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Web.Areas.Member.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Entities.DTO.UrgencyDTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Entities.DTO.AppUserDTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Entities.DTO.NotificationDTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Entities.DTO.ReportDTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\_ViewImports.cshtml"
using NLayer_Workflow.Entities.DTO.WorkDTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38fe7e1f84ee1c5c5fa3b6c7cbcc6f6d2613d6b1", @"/Areas/Member/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b53097e979aa60de35ed9a9d0a491c89d113926", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetStatisticsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""row mt-3"">
        <div class=""col-md-6"">
            <div class=""card text-white bg-primary mb-3"" style=""max-width: 30rem;"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Rapor Sayısı</h4>
                    <p class=""card-text display-4"">");
#nullable restore
#line 8 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\Home\Index.cshtml"
                                              Write(Model.ReportCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""card text-white bg-warning mb-3"" style=""max-width: 30rem;"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Görev Sayısı</h4>
                    <p class=""card-text display-4"">");
#nullable restore
#line 16 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\Home\Index.cshtml"
                                              Write(Model.WorkCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""card text-white bg-secondary mb-3"" style=""max-width: 30rem;"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Okunmamış Bildirim Sayısı</h4>
                    <p class=""card-text display-4"">");
#nullable restore
#line 24 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\Home\Index.cshtml"
                                              Write(Model.NotifyCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""card text-white bg-success mb-3"" style=""max-width: 30rem;"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Tamamlanmamış İş Sayısı</h4>
                    <p class=""card-text display-4"">");
#nullable restore
#line 32 "C:\Users\Blackerback\OneDrive\Masaüstü\NLayer_Workflow\NLayer_Workflow.Web\Areas\Member\Views\Home\Index.cshtml"
                                              Write(Model.NeedCompleteWorksCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetStatisticsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
