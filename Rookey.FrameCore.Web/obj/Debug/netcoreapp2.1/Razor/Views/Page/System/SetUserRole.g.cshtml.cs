#pragma checksum "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93262b595f859c9d4844a49152623114f58064f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_System_SetUserRole), @"mvc.1.0.view", @"/Views/Page/System/SetUserRole.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/System/SetUserRole.cshtml", typeof(AspNetCore.Views_Page_System_SetUserRole))]
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
#line 4 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml"
using Rookey.Frame.Common;

#line default
#line hidden
#line 5 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93262b595f859c9d4844a49152623114f58064f2", @"/Views/Page/System/SetUserRole.cshtml")]
    public class Views_Page_System_SetUserRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml"
  
    ViewBag.Title = "SetUserRole";

#line default
#line hidden
#line 6 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);
   Guid userId = this.Context.Request.Query["userId"].ObjToGuid();

#line default
#line hidden
            BeginContext(258, 49, false);
#line 8 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\System\SetUserRole.cshtml"
Write(Html.Raw(frameFactory.GetSetUserRoleHTML(userId)));

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
