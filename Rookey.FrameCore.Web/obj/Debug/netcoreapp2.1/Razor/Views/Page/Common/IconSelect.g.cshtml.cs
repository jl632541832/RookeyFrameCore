#pragma checksum "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\IconSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8780c13022baff833df3ff327ae621edd0aa2559"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Common_IconSelect), @"mvc.1.0.view", @"/Views/Page/Common/IconSelect.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Common/IconSelect.cshtml", typeof(AspNetCore.Views_Page_Common_IconSelect))]
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
#line 4 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\IconSelect.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8780c13022baff833df3ff327ae621edd0aa2559", @"/Views/Page/Common/IconSelect.cshtml")]
    public class Views_Page_Common_IconSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\IconSelect.cshtml"
  
    ViewBag.Title = "IconSelect";

#line default
#line hidden
#line 5 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\IconSelect.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);

#line default
#line hidden
            BeginContext(160, 42, false);
#line 6 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\IconSelect.cshtml"
Write(Html.Raw(frameFactory.GetIconSelectHTML()));

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