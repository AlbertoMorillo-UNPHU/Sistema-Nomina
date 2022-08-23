using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data;
using SistemaNomina.Models;

namespace SistemaNomina.Controllers
{
    public class HorasExtrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorasExtrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HorasExtras.Include(h => h.Payment);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtras = await _context.HorasExtras
                .Include(h => h.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horasExtras == null)
            {
                return NotFound();
            }

            return View(horasExtras);
        }

        public async Task<IActionResult> DetailsPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtras = await _context.HorasExtras
                .Include(h => h.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horasExtras == null)
            {
                return NotFound();
            }

            return View(horasExtras);
        }

        public IActionResult Create()
        {
            ViewData["PaymentId"] = new SelectList(_context.Payments.Include(e=>e.Employee), "Id", "Employee.NombreCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CantidadMes,FechaEfectiva,FechaCreacion,PaymentId")] HorasExtras horasExtras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horasExtras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentId"] = new SelectList(_context.Payments.Include(e => e.Employee), "Id", "Employee.NombreCompleto", horasExtras.PaymentId);
            return View(horasExtras);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtras = await _context.HorasExtras.FindAsync(id);
            if (horasExtras == null)
            {
                return NotFound();
            }
            ViewData["PaymentId"] = new SelectList(_context.Payments.Include(e => e.Employee), "Id", "Employee.NombreCompleto", horasExtras.PaymentId);
            return View(horasExtras);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CantidadMes,FechaEfectiva,FechaCreacion,PaymentId")] HorasExtras horasExtras)
        {
            if (id != horasExtras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horasExtras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorasExtrasExists(horasExtras.Id))
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
            ViewData["PaymentId"] = new SelectList(_context.Payments.Include(e => e.Employee), "Id", "Employee.NombreCompleto", horasExtras.PaymentId);
            return View(horasExtras);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtras = await _context.HorasExtras
                .Include(h => h.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horasExtras == null)
            {
                return NotFound();
            }

            return View(horasExtras);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var horasExtras = await _context.HorasExtras.FindAsync(id);
            _context.HorasExtras.Remove(horasExtras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorasExtrasExists(long id)
        {
            return _context.HorasExtras.Any(e => e.Id == id);
        }
    }
}
