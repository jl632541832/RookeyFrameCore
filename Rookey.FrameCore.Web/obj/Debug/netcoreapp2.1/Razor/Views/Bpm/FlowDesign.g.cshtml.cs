#pragma checksum "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da02c125f9febfa3e13d532beb5059c04e3fa4c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bpm_FlowDesign), @"mvc.1.0.view", @"/Views/Bpm/FlowDesign.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bpm/FlowDesign.cshtml", typeof(AspNetCore.Views_Bpm_FlowDesign))]
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
#line 1 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
using Rookey.Frame.Common;

#line default
#line hidden
#line 10 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da02c125f9febfa3e13d532beb5059c04e3fa4c4", @"/Views/Bpm/FlowDesign.cshtml")]
    public class Views_Bpm_FlowDesign : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
  
    ViewBag.Title = "FlowDesign";
    string r = WebHelper.GetJsModifyTimeStr("/Scripts/Bpm/FlowDesign.js");

#line default
#line hidden
            DefineSection("scripts", async() => {
                BeginContext(166, 36, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 202, "\"", 274, 1);
#line 8 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
WriteAttributeValue("", 208, Url.Content(string.Format("~/Scripts/Bpm/FlowDesign.js?r={0}",r)), 208, 66, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(275, 12, true);
                WriteLiteral("></script>\r\n");
                EndContext();
            }
            );
#line 11 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);

#line default
#line hidden
            BeginContext(408, 42, false);
#line 12 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Bpm\FlowDesign.cshtml"
Write(Html.Raw(frameFactory.GetFlowDesignHTML()));

#line default
#line hidden
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