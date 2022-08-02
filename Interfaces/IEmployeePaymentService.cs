using SistemaNomina.Models;
using SistemaNomina.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Interfaces
{
    public interface IEmployeePaymentService
    {
        Task<EmpPayModels.EmpAddUpdateFeedback> AddUpdateEmployee(Employee employee);

        Task<Employee> GetEmployee(long id);

        Task<List<Employee>> GetAllEmployees();

        Task<EmpPayModels.PaymentFeedback> RecordPayment(Payment payment);

        Task<IEnumerable<Employee>> GetAllEmployeesWithPayments();

        Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(long empId);

        Task<IEnumerable<Payment>> GetPagedPaymentsForEmployee(long empId, int page);

        Task<Tuple<decimal, decimal>> GetYtdPay(long empId);
    }
}
