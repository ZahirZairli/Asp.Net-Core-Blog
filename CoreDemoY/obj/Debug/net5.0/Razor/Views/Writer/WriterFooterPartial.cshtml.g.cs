#pragma checksum "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Writer\WriterFooterPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1730fadf52127f1f742ae7b1a696aa971c06df6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Writer_WriterFooterPartial), @"mvc.1.0.view", @"/Views/Writer/WriterFooterPartial.cshtml")]
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
#line 1 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\_ViewImports.cshtml"
using CoreDemoY;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\_ViewImports.cshtml"
using CoreDemoY.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1730fadf52127f1f742ae7b1a696aa971c06df6c", @"/Views/Writer/WriterFooterPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988bf3418fa3f25744dcdcbdbeb808bf31ff49a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Writer_WriterFooterPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<footer class=\"footer\">\r\n    <div class=\"container-fluid clearfix\">\r\n        <span class=\"text-muted d-block text-center text-sm-left d-sm-inline-block\">Copyright © Bütün hüquqlar qorunur ");
#nullable restore
#line 3 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Writer\WriterFooterPartial.cshtml"
                                                                                                                  Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <span class=\"float-none float-sm-right d-block mt-1 mt-sm-0 text-center\"> Zairli Zahir <a href=\"https://www.bootstrapdash.com/bootstrap-admin-template/\" target=\"_blank\"></a></span>\r\n    </div>\r\n</footer>\r\n");
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
