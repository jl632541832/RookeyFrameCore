#pragma checksum "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb6f31d12bf254d7a32615c29be6fb0d004364a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quartz_AddJobPlan), @"mvc.1.0.view", @"/Views/Quartz/AddJobPlan.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Quartz/AddJobPlan.cshtml", typeof(AspNetCore.Views_Quartz_AddJobPlan))]
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
#line 22 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb6f31d12bf254d7a32615c29be6fb0d004364a0", @"/Views/Quartz/AddJobPlan.cshtml")]
    public class Views_Quartz_AddJobPlan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml"
  
    ViewBag.Title = "AddJobPlan";

#line default
#line hidden
            DefineSection("scripts", async() => {
                BeginContext(59, 375, true);
                WriteLiteral(@"
    <style type=""text/css"">
        .td_text {
            text-align: right;
            font-size: 13px;
            width: 150px;
            height: 30px;
        }

        .td_value {
            text-align: left;
            font-size: 13px;
            width: 400px;
            height: 30px;
        }
    </style>
    <script type=""text/javascript""");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 434, "\"", 486, 1);
#line 20 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml"
WriteAttributeValue("", 440, Url.Content("~/Scripts/Quartz/AddJobPlan.js"), 440, 46, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(487, 12, true);
                WriteLiteral("></script>\r\n");
                EndContext();
            }
            );
#line 23 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);

#line default
#line hidden
            BeginContext(620, 42, false);
#line 24 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Quartz\AddJobPlan.cshtml"
Write(Html.Raw(frameFactory.GetAddJobPlanHTML()));

#line default
#line hidden
            EndContext();
            BeginContext(662, 2, true);
            WriteLiteral("\r\n");
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
