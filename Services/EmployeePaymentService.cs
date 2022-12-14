using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data;
using SistemaNomina.Interfaces;
using SistemaNomina.Models;
using SistemaNomina.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Services
{
    public class EmployeePaymentService : IEmployeePaymentService
    {
        // constructor
        ApplicationDbContext _dbContext;
        public EmployeePaymentService()
        {
            this._dbContext = new ApplicationDbContext();
        }

        #region Employee

        // add or update employee
        public async Task<EmpPayModels.EmpAddUpdateFeedback> AddUpdateEmployee(Employee employee)
        {
            // check required fields
            if (string.IsNullOrEmpty(employee.SSN))
            {
                // return error
                return new EmpPayModels.EmpAddUpdateFeedback
                {
                    Success = false,
                    Errors = "SSN del empleado inválido."
                };
            }

            using (var db = new ApplicationDbContext())
            {
                // check if employee exists
                var prevEmpl = await db.Employees.FirstOrDefaultAsync(x => x.SSN == employee.SSN);

                // if adding new employee
                if (employee.Id == 0)
                {
                    // check if employee exists
                    if (prevEmpl != null)
                    {
                        // return error
                        return new EmpPayModels.EmpAddUpdateFeedback
                        {
                            Success = false,
                            Errors = "Empleado ya existe."
                        };
                    }

                    // if here valid employee
                    await db.Employees.AddAsync(employee);
                    await db.SaveChangesAsync();
                }
                else
                {
                    // check if employee exists
                    if (prevEmpl == null)
                    {
                        // return error
                        return new EmpPayModels.EmpAddUpdateFeedback
                        {
                            Success = false,
                            Errors = "Empleado no existe"
                        };
                    }

                    // if here update employee
                    prevEmpl.FirstName = employee.FirstName;
                    prevEmpl.LastName = employee.LastName;
                    prevEmpl.AFP = employee.AFP;
                    prevEmpl.ARS = employee.ARS;
                    prevEmpl.ISR = employee.ISR;
                    prevEmpl.RetirementPercent = employee.RetirementPercent;
                    db.Employees.Update(prevEmpl);
                    await db.SaveChangesAsync();
                }

                // if here success
                return new EmpPayModels.EmpAddUpdateFeedback
                {
                    Success = true,
                    EmpId = employee.Id
                };
            }
        }

        // get single employee by empl id
        public async Task<Employee> GetEmployee(long id)
        {
            using (var db = new ApplicationDbContext())
            {
                // check if employee exists
                return await db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        // get all employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            using (var db = new ApplicationDbContext())
            {
                // check if employee exists
                return await db.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();
            }
        }

        // get all employee with payments
        public async Task<IEnumerable<Employee>> GetAllEmployeesWithPayments()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Employees.Include(x => x.Payments).ToListAsync();
            }
        }

        #endregion

        #region Payments

        // record payment
        public async Task<EmpPayModels.PaymentFeedback> RecordPayment(Payment payment)
        {
            // check if valid employee
            var empl = await GetEmployee(payment.EmpId);
            if (empl == null)
            {
                // return error
                return new EmpPayModels.PaymentFeedback
                {
                    Success = false,
                    Errors = "Invalid Employee."
                };
            }

            // check if valid gross pay
            if (payment.GrossPay <= 0)
            {
                // return error
                return new EmpPayModels.PaymentFeedback
                {
                    Success = false,
                    Errors = "Invalid Pay. Gross pay should be more than 0."
                };
            }

            // check if valid pay
            if (payment.NetPay < 0)
            {
                // return error
                return new EmpPayModels.PaymentFeedback
                {
                    Success = false,
                    Errors = "Invalid Pay. Net pay cannot be less than 0."
                };
            }

            // check pay range
            if (payment.PaymentPeriodFrom > payment.PaymentPeriodTo)
            {
                // return error
                return new EmpPayModels.PaymentFeedback
                {
                    Success = false,
                    Errors = "Invalid Pay Period. Start date should be less than End date."
                };
            }

            // if here valid pay
            // set payment date
            payment.CreateDateTime = DateTime.Now;

            // save
            using (var db = new ApplicationDbContext())
            {
                await db.Payments.AddAsync(payment);
                await db.SaveChangesAsync();
            }

            // return success
            return new EmpPayModels.PaymentFeedback
            {
                Success = true,
                EmpId = empl.Id
            };
        }

        // get all payments for employee
        public async Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(long empId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Payments.Where(x => x.EmpId == empId).ToListAsync();
            }
        }

        // get paged results of employee payments
        public async Task<IEnumerable<Payment>> GetPagedPaymentsForEmployee(long empId, int page)
        {
            if (page < 1) page = 1;
            var limit = 10;
            var startFrom = (page - 1) * limit;
            using (var db = new ApplicationDbContext())
            {
                return await db.Payments.Where(x => x.EmpId == empId).OrderByDescending(x => x.CreateDateTime).Skip(startFrom).Take(limit).ToListAsync();
            }
        }

        // get ytd gross & net pay for employee
        public async Task<Tuple<decimal, decimal>> GetYtdPay(long empId)
        {
            var payments = await GetAllPaymentsForEmployee(empId);
            var yearPay = payments.Where(x => x.CreateDateTime >= new DateTime(DateTime.Now.Year, 1, 1)).ToList();
            var ytdGross = yearPay.Sum(x => x.GrossPay);
            var ytdNet = yearPay.Sum(x => x.NetPay);

            // return ytd pay
            return new Tuple<decimal, decimal>(ytdGross, ytdNet);
        }

        #endregion
    }
}
