#pragma checksum "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2298610f569858cd44e6138480b8eabc5076519"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Common_ViewForm), @"mvc.1.0.view", @"/Views/Page/Common/ViewForm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Common/ViewForm.cshtml", typeof(AspNetCore.Views_Page_Common_ViewForm))]
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
#line 1 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml"
using Rookey.Frame.Common;

#line default
#line hidden
#line 2 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml"
using Rookey.Frame.UIOperate;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2298610f569858cd44e6138480b8eabc5076519", @"/Views/Page/Common/ViewForm.cshtml")]
    public class Views_Page_Common_ViewForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml"
   UIFrameFactory frameFactory = UIFrameFactory.GetInstance(this.Context.Request);
   Guid moduleId = UIOperate.GetModuleIdByRequest(this.Context.Request);
   Guid id = this.Context.Request.Query["id"].ObjToGuid();
   string gridId = this.Context.Request.Query["gridId"].ObjToStr(); //网格行内展开查看表单的主网格domId
   string ff = this.Context.Request.Query["ff"].ObjToStr(); //从表单页面点击查看标识
   bool isRecycle = this.Context.Request.Query["recycle"].ObjToInt() == 1; //是否从回收站加载
   bool showTip = this.Context.Request.Query["tip"].ObjToInt() == 1;
   Guid? formId = this.Context.Request.Query["formId"].ObjToGuidNull(); //表单ID

#line default
#line hidden
#line 12 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml"
  
    ViewBag.Title = "ViewForm";

#line default
#line hidden
            BeginContext(726, 112, false);
#line 15 "D:\.NET CORE\MyCode\OneDll\RookeyFrameCoreOneDLL\Rookey.FrameCore.Web\Views\Page\Common\ViewForm.cshtml"
Write(Html.Raw(frameFactory.GetViewFormHTML(moduleId, id, gridId, ff, isRecycle, showTip, null, this.Context.Request)));

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