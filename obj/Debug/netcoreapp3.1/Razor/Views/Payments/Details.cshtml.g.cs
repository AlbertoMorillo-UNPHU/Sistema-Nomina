#pragma checksum "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3097c71ae8ee2afd4a647653e13abd1f99b4dd8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_Details), @"mvc.1.0.view", @"/Views/Payments/Details.cshtml")]
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
#line 1 "C:\Users\amori\source\repos\SistemaNomina\Views\_ViewImports.cshtml"
using SistemaNomina;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amori\source\repos\SistemaNomina\Views\_ViewImports.cshtml"
using SistemaNomina.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\amori\source\repos\SistemaNomina\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3097c71ae8ee2afd4a647653e13abd1f99b4dd8f", @"/Views/Payments/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80f8de4d2327b3de92c6add9614b416922daf98b", @"/Views/_ViewImports.cshtml")]
    public class Views_Payments_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SistemaNomina.Models.Payment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
  
    ViewData["Title"] = "Detalle Salario";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalle</h1>\r\n\r\n<div class=\"card p-3\" id=\"pdfContainerHtml\">\r\n    <h4>Pago del mes</h4>\r\n    <div class=\"text-right\">\r\n        <button value=\"Convert PDF\" id=\"btnPDF\" class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 286, "\"", 392, 2);
#nullable restore
#line 12 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
WriteAttributeValue("", 296, "window.location.href='" + @Url.Action("DetailsPrint", "Payments", new { id=Model.Id}) + "'", 296, 95, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 391, ";", 391, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-print\" aria-hidden=\"true\"></i></button>\r\n    </div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 17 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GrossPay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 20 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.GrossPay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 23 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentPeriodFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 26 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentPeriodFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 29 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentPeriodTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n");
#nullable restore
#line 32 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
             if (Model.PaymentPeriodTo != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
           Write(Html.DisplayFor(model => model.PaymentPeriodTo, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
                                                                                                
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-success\">PERMANECE</span>\r\n");
#nullable restore
#line 39 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 42 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ISR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 45 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.ISR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 48 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AFP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 51 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.AFP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 54 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ARS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 57 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.ARS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 60 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ARL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 63 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.ARL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 66 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 69 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.TSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 72 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.INFOTEP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 75 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.INFOTEP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 78 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Retirement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 81 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Retirement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 84 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NetPay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 87 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.NetPay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 90 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreateDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 93 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreateDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 96 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 99 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            ");
#nullable restore
#line 102 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HorasExtras));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 105 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(ViewBag.CantHE);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-7\">\r\n            Pago Horas Extras\r\n        </dt>\r\n        <dd class=\"col-sm-5\">\r\n            ");
#nullable restore
#line 111 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
       Write(ViewBag.PagoHE);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3097c71ae8ee2afd4a647653e13abd1f99b4dd8f15561", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
                               WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3097c71ae8ee2afd4a647653e13abd1f99b4dd8f17788", async() => {
                WriteLiteral("Volver");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 122 "C:\Users\amori\source\repos\SistemaNomina\Views\Payments\Details.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script>
        

        function MyFunction() {
            var sHtml = $(""#pdfContainerHtml"").html();
            sHtml = sHtml.replace(/</g, ""StrTag"").replace(/>/g, ""EndTag"");
            console.log(sHtml)
            var data = {
                html: sHtml,
            };
            $.ajax({
                url: ""../GenerateDetallePDF"",
                type: ""POST"",
                dataType: ""text/plain"",
                data: {
                    html: sHtml
                },
                success: function (data) {
                    console.log(""Impreso detalle pago"");
                }
            });
            return false;
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SistemaNomina.Models.Payment> Html { get; private set; }
    }
}
#pragma warning restore 1591
