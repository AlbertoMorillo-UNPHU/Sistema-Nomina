#pragma checksum "C:\Users\amori\source\repos\SistemaNomina\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c30ebf8018d6aed6371c4041d867003bd94b2c80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c30ebf8018d6aed6371c4041d867003bd94b2c80", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80f8de4d2327b3de92c6add9614b416922daf98b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<style>\r\n    ");
            WriteLiteral(@"@import url('https://fonts.googleapis.com/css2?family=Sriracha&display=swap');

    body {
      margin: 0;
      box-sizing: border-box;
    }

    /* CSS for header */
    .header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      background-color: #f5f5f5;
    }

    .header .logo {
      font-size: 25px;
      font-family: 'Sriracha', cursive;
      color: #000;
      text-decoration: none;
      margin-left: 30px;
    }

    .nav-items {
      display: flex;
      justify-content: space-around;
      align-items: center;
      background-color: #f5f5f5;
      margin-right: 20px;
    }

    .nav-items a {
      text-decoration: none;
      color: #000;
      padding: 35px 20px;
    }

    /* CSS for main element */
    .intro {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      width: 100%;
      height: 520px;
      background: linear-gradient(to bottom, ");
            WriteLiteral(@"rgba(0, 0, 0, 0.5) 0%, rgba(0, 0, 0, 0.5) 100%), url(""https://images.unsplash.com/photo-1587620962725-abab7fe55159?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1031&q=80"");
      background-size: cover;
      background-position: center;
      background-repeat: no-repeat;
    }

    .intro h1 {
      font-family: sans-serif;
      font-size: 60px;
      color: #fff;
      font-weight: bold;
      text-transform: uppercase;
      margin: 0;
    }

    .intro p {
      font-size: 20px;
      color: #d1d1d1;
      text-transform: uppercase;
      margin: 20px 0;
    }

    .intro button {
      background-color: #5edaf0;
      color: #000;
      padding: 10px 25px;
      border: none;
      border-radius: 5px;
      font-size: 20px;
      font-weight: bold;
      cursor: pointer;
      box-shadow: 0px 0px 20px rgba(255, 255, 255, 0.4)
    }

    .achievements {
      display: flex;
      justify-content: space-around;
      align-it");
            WriteLiteral(@"ems: center;
      padding: 40px 80px;
    }

    .achievements .work {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      padding: 0 40px;
    }

    .achievements .work i {
      width: fit-content;
      font-size: 50px;
      color: #333333;
      border-radius: 50%;
      border: 2px solid #333333;
      padding: 12px;
    }

    .achievements .work .work-heading {
      font-size: 20px;
      color: #333333;
      text-transform: uppercase;
      margin: 10px 0;
    }

    .achievements .work .work-text {
      font-size: 15px;
      color: #585858;
      margin: 10px 0;
    }

    .about-me {
      display: flex;
      justify-content: center;
      align-items: center;
      padding: 40px 80px;
      border-top: 2px solid #eeeeee;
    }

    .about-me img {
      width: 500px;
      max-width: 100%;
      height: auto;
      border-radius: 10px;
    }

    .about-me-text h2 {
      font-si");
            WriteLiteral(@"ze: 30px;
      color: #333333;
      text-transform: uppercase;
      margin: 0;
    }

    .about-me-text p {
      font-size: 15px;
      color: #585858;
      margin: 10px 0;
    }

    /* CSS for footer */
    .footer {
      display: flex;
      justify-content: space-between;
      align-items: center;
      background-color: #302f49;
      padding: 40px 80px;
    }

    .footer .copy {
      color: #fff;
    }

    .bottom-links {
      display: flex;
      justify-content: space-around;
      align-items: center;
      padding: 40px 0;
    }

    .bottom-links .links {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      padding: 0 40px;
    }

    .bottom-links .links span {
      font-size: 20px;
      color: #fff;
      text-transform: uppercase;
      margin: 10px 0;
    }

    .bottom-links .links a {
      text-decoration: none;
      color: #a1a1a1;
      padding: 10px 20px;
    }
");
            WriteLiteral(@"</style>
<header class=""header"">
    <a href=""#"" class=""logo"">Undertaker</a>
</header>
<main>
    <div class=""intro"">
        <h1>Sistema de nomina</h1>
        <p class=""p-2 text-center"">La elaboración de nóminas es un proceso vital para el funcionamiento de tu empresa, ya que es el registro financiero de los pagos a tus empleados de manera constante y ordenada; generalmente el completado de la nómina se realiza de manera manual, lo cual representa un trabajo complejo que requiere de una gran cantidad de tiempo y de recursos, además de que no garantiza que tus empleados confíen que su pago esté sin errores, ni retrasos.</p>
        <button>Ver Más</button>
    </div>
    <div class=""achievements"">
        <div class=""work"">
            <i class=""fas fa-atom""></i>
            <p class=""work-heading"">Ahorra costos y tiempo</p>
            <p class=""work-text"">En las empresas en las que realizan sus nóminas manualmente, algunas cuentan con un empleado fijo dedicado su captura, sin embargo, otras e");
            WriteLiteral(@"mpresas no se pueden dar ese lujo, por lo que su personal de recursos humanos o de contabilidad.</p>
        </div>
        <div class=""work"">
            <i class=""fas fa-skiing""></i>
            <p class=""work-heading"">Aumenta la confianza de tus empleados con la empresa</p>
            <p class=""work-text"">En las empresas en las que realizan sus nóminas manualmente, algunas cuentan con un empleado fijo dedicado su captura, sin embargo, otras empresas no se pueden dar ese lujo, por lo que su personal de recursos humanos o de contabilidad.</p>
        </div>
        <div class=""work"">
            <i class=""fas fa-ethernet""></i>
            <p class=""work-heading"">Facilita el cálculo de las variables en los sueldos</p>
            <p class=""work-text"">El calcular el sueldo con las variables como las horas extras suele tomar tiempo cuando se realiza manualmente ya que se tiene que hacer un análisis del reporte de horas extra por el periodo a pagar.</p>
        </div>
    </div>
    <div class=""abo");
            WriteLiteral(@"ut-me"">
        <div class=""about-me-text"">
            <h2>Sobre nosotros</h2>
            <p>Empresa dedicada a la transformación digital implementado lo último en tecnología para nuestros clientes.</p>
        </div>
        <img src=""https://solowrestling.mundodeportivo.com/uploads/RESEM106152undertaker.jpg"" alt=""me"">
    </div>
</main>");
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
