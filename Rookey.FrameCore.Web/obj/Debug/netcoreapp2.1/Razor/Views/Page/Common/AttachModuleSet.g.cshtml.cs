#pragma checksum "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\AttachModuleSet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba901128d94d3e106836f9223f4eb32c900d3b27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Common_AttachModuleSet), @"mvc.1.0.view", @"/Views/Page/Common/AttachModuleSet.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Common/AttachModuleSet.cshtml", typeof(AspNetCore.Views_Page_Common_AttachModuleSet))]
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
#line 4 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\AttachModuleSet.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba901128d94d3e106836f9223f4eb32c900d3b27", @"/Views/Page/Common/AttachModuleSet.cshtml")]
    public class Views_Page_Common_AttachModuleSet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\AttachModuleSet.cshtml"
  
    ViewBag.Title = "AttachModuleSet";

#line default
#line hidden
#line 5 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\AttachModuleSet.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);
   Guid moduleId = UIOperate.GetModuleIdByRequest(this.Context.Request);

#line default
#line hidden
            BeginContext(239, 55, false);
#line 7 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\AttachModuleSet.cshtml"
Write(Html.Raw(frameFactory.GetAttachModuleSetHTML(moduleId)));

#line default
#line hidden
            EndContext();
            BeginContext(294, 2, true);
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
