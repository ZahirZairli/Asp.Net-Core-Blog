#pragma checksum "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7baeb12073a68648bad9a52a63c2ef5d5fa216bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_EditBlog), @"mvc.1.0.view", @"/Views/Blog/EditBlog.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7baeb12073a68648bad9a52a63c2ef5d5fa216bc", @"/Views/Blog/EditBlog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988bf3418fa3f25744dcdcbdbeb808bf31ff49a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_EditBlog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntityLayer.Concrete.Blog>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
  
    ViewData["Title"] = "EditBlog";
    Layout = "~/Views/Shared/WriterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Bloga düzəliş et!</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
 using (Html.BeginForm("EditBlog", "Blog", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.HiddenFor(x => x.BlogId, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                   ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 13 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.Label("Blog başlıq"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                              ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.TextBoxFor(x => x.BlogTitle, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                       ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.ValidationMessageFor(x => x.BlogTitle, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                    ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 17 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.Label("Blog balaca şəkil linki"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                          ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.TextBoxFor(x => x.BlogThumbnailImage, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.ValidationMessageFor(x => x.BlogThumbnailImage, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                             ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 21 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.Label("Blog şəkil linki"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                   ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.TextBoxFor(x => x.BlogImage, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                       ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.ValidationMessageFor(x => x.BlogImage, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                    ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 25 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.Label("Blog kateqoryası"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                   ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.DropDownListFor(x => x.CategoryId, (List<SelectListItem>)ViewBag.cv, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 28 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.Label("Blog mətni"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                             ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.TextAreaFor(x => x.BlogContent, 10, 3, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                 ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
Write(Html.ValidationMessageFor(x => x.BlogContent, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
                                                                                      ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-success\" onclick=\"return confirm(\'Dəyişikliklər yadda saxlanılsınmı?\')\">Yadda saxla</button>\r\n");
#nullable restore
#line 33 "C:\Users\Casper\source\repos\CoreDemoY\CoreDemoY\Views\Blog\EditBlog.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntityLayer.Concrete.Blog> Html { get; private set; }
    }
}
#pragma warning restore 1591
