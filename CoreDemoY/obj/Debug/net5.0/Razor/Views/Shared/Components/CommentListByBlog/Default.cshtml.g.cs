#pragma checksum "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f07cdabbb068fe41d9ee6ca5a1447f87bf9b77dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CommentListByBlog_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CommentListByBlog/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f07cdabbb068fe41d9ee6ca5a1447f87bf9b77dc", @"/Views/Shared/Components/CommentListByBlog/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988bf3418fa3f25744dcdcbdbeb808bf31ff49a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CommentListByBlog_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EntityLayer.Concrete.Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"comment-top\">\r\n");
#nullable restore
#line 3 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
     if (Model.Count() != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Yorumlar</h4>\r\n");
#nullable restore
#line 6 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"media\">\r\n                <img style=\"width: 10%;border-radius: 50%;\" src=\"https://www.pikpng.com/pngl/b/74-748374_laptop-user-personal-computer-computer-icons-computer-user.png\"");
            BeginWriteAttribute("alt", " alt=\"", 387, "\"", 393, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" />\r\n                <div class=\"media-body\">\r\n                    <h5 class=\"mt-0\">");
#nullable restore
#line 11 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
                                Write(item.CommentUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p>\r\n                        ");
#nullable restore
#line 13 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
                   Write(item.CommentContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 17 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>??lk yorum yazan s??n ol!</h4>\r\n");
#nullable restore
#line 22 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Shared\Components\CommentListByBlog\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EntityLayer.Concrete.Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
