using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SelectPdf;
using SistemaNomina.Data;
using SistemaNomina.Models;

namespace SistemaNomina.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Payments.Include(p => p.Employee);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "ADMIN,CONTABLE")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Employee).Include(h => h.HorasExtras)
                .FirstOrDefaultAsync(m => m.Id == id);

            //var horas = payment.HorasExtras.Sum(h => h.CantidadMes);
            ViewData["CantHE"] = 0;
            ViewData["PagoHE"] = 0;
            if (payment.HorasExtras.Any())
            {
                var horaPago = 0m;
                var cm = payment.HorasExtras.Where(s=>s.FechaEfectiva.Month == DateTime.Now.Month).Sum(h => h.CantidadMes);
                if (cm > 16)
                {
                    ViewData["CantHE"] = cm;
                    horaPago = payment.NetPay / 160;
                    ViewData["PagoHE"] = Math.Round(((horaPago * 1.35m) * cm) + payment.NetPay,2);
                }else if (cm > 112)
                {
                    ViewData["CantHE"] = cm;
                    horaPago = payment.NetPay / 160;
                    ViewData["PagoHE"] = Math.Round(((horaPago * 2) * cm) + payment.NetPay,2);
                }
            }
            
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        public async Task<IActionResult> DetailsPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Employee).Include(h => h.HorasExtras)
                .FirstOrDefaultAsync(m => m.Id == id);

            //var horas = payment.HorasExtras.Sum(h => h.CantidadMes);
            ViewData["CantHE"] = 0;
            ViewData["PagoHE"] = 0;
            if (payment.HorasExtras.Any())
            {
                var horaPago = 0m;
                var cm = payment.HorasExtras.Where(s => s.FechaEfectiva.Month == DateTime.Now.Month).Sum(h => h.CantidadMes);
                if (cm > 16)
                {
                    ViewData["CantHE"] = cm;
                    horaPago = payment.NetPay / 160;
                    ViewData["PagoHE"] = Math.Round(((horaPago * 1.35m) * cm) + payment.NetPay, 2);
                }
                else if (cm > 112)
                {
                    ViewData["CantHE"] = cm;
                    horaPago = payment.NetPay / 160;
                    ViewData["PagoHE"] = Math.Round(((horaPago * 2) * cm) + payment.NetPay, 2);
                }
            }

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost]
        public IActionResult GenerateDetallePDF(string html)
        {
            html = html.Replace("StrTag", "<").Replace("EndTag", ">").Replace("\n", "").Replace("\r", "");
            html = html.Trim();
            HtmlToPdf htmlToPdf = new HtmlToPdf();
            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(html);
            byte[] pdf = pdfDocument.Save();
            pdfDocument.Close();
            MemoryStream ms = new MemoryStream();
            ms.Write(pdf, 0, pdf.Length);
            //fix
            ms.Position = 0;

            // also tried
            //return File(ms, "application/pdf", mergedFileName);

            return new FileStreamResult(ms, new MediaTypeHeaderValue("application/pdf"))
            {
                FileDownloadName = "DetallePago.pdf"
            };
        }


        [Authorize(Roles = "ADMIN,CONTABLE")]
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "NombreCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpId,GrossPay,PaymentPeriodFrom,PaymentPeriodTo,ISR,AFP,ARS,ARL,TSS,INFOTEP,NetPay")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.CreateDateTime = DateTime.Now;
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "NombreCompleto", payment.EmpId);
            return View(payment);
        }
        [Authorize(Roles = "ADMIN,CONTABLE")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "NombreCompleto", payment.EmpId);
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,EmpId,GrossPay,PaymentPeriodFrom,PaymentPeriodTo,ISR,AFP,ARS,ARL,TSS,INFOTEP,Retirement,NetPay,CreateDateTime")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "NombreCompleto", payment.EmpId);
            return View(payment);
        }
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(long id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
