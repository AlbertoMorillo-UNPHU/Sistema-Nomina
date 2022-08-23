using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data;
using SistemaNomina.Helpers;
using SistemaNomina.Interfaces;
using SistemaNomina.Models;
using SistemaNomina.ModelView;
using SistemaNomina.Services;

namespace SistemaNomina.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Listing()
        {

            var emplList = await new EmployeePaymentService().GetAllEmployees();
            var stateList = StatesGenerator.List;
            var model = new ListingModels.ViewModel
            {
                EmplList = emplList.Select(x => new DropdownListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.FirstName} {x.LastName}"
                }),
                StatesList = stateList.Select(x => new DropdownListItem
                {
                    Value = x.Abbreviation,
                    Text = $"{x.Name}"
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetListFiltered(ListingModels.ListingRequest request)
        {
            return Ok(await new ListingService().GetListFiltered(request));
        }
        
        [HttpGet("/[controller]/{empId}/[action]")]
        public async Task<IActionResult> Payments(long empId)
        {
            return View(empId);
        }

        public IActionResult AddEmployeeDialog()
        {
            return View("Partials/AddEmployee");
        }
        
        public IActionResult RecordPayDialog(long id)
        {
            return View("Partials/RecordPay", id);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [Authorize(Roles ="ADMIN")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,SSN,AFP,ISR,ARS,Direccion,FechaNacimiento,Puesto")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.CreateDateTime = DateTime.Now;
                employee.RetirementPercent = Convert.ToDecimal(2.87);
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,State,SSN,AFP,ISR,ARS,RetirementPercent,CreateDateTime,Direccion,FechaNacimiento,Puesto")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
