#pragma checksum "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e50c1f8d2169652f419bb602ac458203d27f7f32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Common_DocView), @"mvc.1.0.view", @"/Views/Page/Common/DocView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Common/DocView.cshtml", typeof(AspNetCore.Views_Page_Common_DocView))]
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
#line 1 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
using Rookey.Frame.Common;

#line default
#line hidden
#line 2 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
using System.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e50c1f8d2169652f419bb602ac458203d27f7f32", @"/Views/Page/Common/DocView.cshtml")]
    public class Views_Page_Common_DocView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
   string fn = HttpUtility.UrlDecode(this.Context.Request.Query["fn"].ObjToStr());

#line default
#line hidden
#line 4 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
  
    ViewBag.Title = fn;

#line default
#line hidden
            DefineSection("scripts", async() => {
                BeginContext(183, 36, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 219, "\"", 282, 1);
#line 8 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
WriteAttributeValue("", 225, Url.Content("~/Scripts/FlexPaper/js/flexpaper_flash.js"), 225, 57, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(283, 46, true);
                WriteLiteral("></script>\r\n    <script type=\"text/javascript\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 329, "\"", 396, 1);
#line 9 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
WriteAttributeValue("", 335, Url.Content("~/Scripts/FlexPaper/js/swfobject/swfobject.js"), 335, 61, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(397, 1234, true);
                WriteLiteral(@"></script>
    <script type=""text/javascript"">
        <!-- For version detection, set to min. required Flash Player version, or 0 (or 0.0.0), for no version detection. -->
    var swfVersionStr = ""10.0.0"";
    var xiSwfUrlStr = ""playerProductInstall.swf"";
    var swfUrl = decodeURI(GetLocalQueryString(""swfUrl""));
    var flashvars = {
        SwfFile: swfUrl,
        Scale: 0.6,
        ZoomTransition: ""easeOut"",
        ZoomTime: 0.5,
        ZoomInterval: 0.1,
        FitPageOnLoad: false,
        FitWidthOnLoad: true,
        PrintEnabled: true,
        PrintToolsVisible: true,
        FullScreenAsMaxWindow: false,
        ProgressiveLoading: true,
        ViewModeToolsVisible: true,
        ZoomToolsVisible: true,
        FullScreenVisible: true,
        NavToolsVisible: true,
        CursorToolsVisible: true,
        SearchToolsVisible: true,
        localeChain: ""en_US""
    };
    var params = {};
    params.quality = ""high"";
    params.bgcolor = ""#ffffff"";
    params.allow");
                WriteLiteral("scriptaccess = \"sameDomain\";\r\n    params.allowfullscreen = \"true\";\r\n    var attributes = {};\r\n    attributes.id = \"FlexPaperViewer\";\r\n    attributes.name = \"FlexPaperViewer\";\r\n    swfobject.embedSWF(\r\n        \"");
                EndContext();
                BeginContext(1632, 54, false);
#line 44 "D:\.NET CORE\MyCode\OneDll\Rookey.FrameCore\Rookey.FrameCore.Web\Views\Page\Common\DocView.cshtml"
    Write(Url.Content("~/Scripts/FlexPaper/FlexPaperViewer.swf"));

#line default
#line hidden
                EndContext();
                BeginContext(1686, 229, true);
                WriteLiteral("\", \"flashContent\",\r\n        \"1024\", \"768\",\r\n        swfVersionStr, xiSwfUrlStr,\r\n        flashvars, params, attributes);\r\n    swfobject.createCSS(\"#flashContent\", \"display:block;text-align:left;margin: 0 auto;\");\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(1918, 89, true);
            WriteLiteral("<div style=\"width: 1024px; margin: 0 auto;\">\r\n    <div id=\"flashContent\"></div>\r\n</div>\r\n");
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
