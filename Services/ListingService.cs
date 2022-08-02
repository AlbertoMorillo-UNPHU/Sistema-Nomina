using Microsoft.EntityFrameworkCore;
using SistemaNomina.Data;
using SistemaNomina.Interfaces;
using SistemaNomina.Models;
using SistemaNomina.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaNomina.Services
{
    public class ListingService : IListingService
    {
        public async Task<ListingModels.ListingResult> GetListFiltered(ListingModels.ListingRequest request)
        {
            var filters = new List<Expression<Func<Employee, bool>>>();

            if (request.EmpId.HasValue)
            {
                filters.Add(x => x.Id == request.EmpId);
            }


            if (request.PayPostingFrom.HasValue)
            {
                filters.Add(x => x.Payments.Any(y => y.CreateDateTime >= request.PayPostingFrom));
            }

            if (request.PayPostingTo.HasValue)
            {
                filters.Add(x => x.Payments.Any(y => y.CreateDateTime < request.PayPostingTo.Value.AddDays(1)));
            }

            List<Employee> filteredList;
            using (var db = new ApplicationDbContext())
            {
                var employees = db.Employees.Include(x => x.Payments).OrderByDescending(x => x.Id).AsQueryable();

                if (filters.Any())
                {
                    foreach (var filter in filters)
                    {
                        employees = employees.Where(filter);
                    }
                }

                filteredList = await employees.ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchPhrase))
            {
                var words = request.SearchPhrase.Split(' ');

                foreach (var word in words)
                {
                    var lowerword = word.ToLower();

                    filteredList = filteredList.Where(x =>
                            x.FirstName.ToLower().Contains(lowerword) ||
                            x.LastName.ToLower().Contains(lowerword) ||
                            x.Payments.Any(y => y.GrossPay.ToString().Equals(lowerword)) ||
                            x.Payments.Any(y => y.NetPay.ToString().Equals(lowerword))
                    ).ToList();
                }
            }

            var transformedList = filteredList.Select(TransformListingItem).ToList();

            var sortedList = GetSortedList(transformedList, request.Sort);

            var partialList = GetPartialList(request.Current, request.RowCount, sortedList);

            return new ListingModels.ListingResult
            {
                Current = request.Current,
                RowCount = request.RowCount,
                Total = filteredList.Count,
                Rows = partialList
            };
        }

        public static ListingModels.ListingItem TransformListingItem(Employee employee)
        {
            var lastPayment = employee.Payments.OrderByDescending(x => x.CreateDateTime).FirstOrDefault();
            var ytdPay = employee.Payments.Where(x => x.CreateDateTime >= new DateTime(DateTime.Now.Year, 1, 1)).Sum(x => x.GrossPay);
            return new ListingModels.ListingItem
            {
                EmpId = employee.Id,
                FullName = $"{employee.FirstName} {employee.LastName}",
                LastPaymentDate = lastPayment?.CreateDateTime.ToString("d") ?? "",
                LastPaymentAmount = lastPayment?.GrossPay.ToString() ?? "",
                YtdPay = ytdPay.ToString()
            };
        }

        public static List<ListingModels.ListingItem> GetSortedList(IEnumerable<ListingModels.ListingItem> rows, Dictionary<string, string> sort)
        {
            if (sort != null && sort.Keys.Any())
            {
                var sortKey = sort.Keys.First();
                var dir = sort[sortKey];

                Func<ListingModels.ListingItem, object> sortFunc;
                switch (sortKey.ToLower())
                {
                    case "fullname":
                        {
                            sortFunc = x => x.FullName;
                            break;
                        }
                    case "lastpaymentdate":
                        {
                            sortFunc = x => x.LastPaymentDate;
                            break;
                        }
                    case "lastpaymentamount":
                        {
                            sortFunc = x => x.LastPaymentAmount;
                            break;
                        }
                    case "ytdpay":
                        {
                            sortFunc = x => x.YtdPay;
                            break;
                        }
                    default:
                        {
                            sortFunc = null;
                            break;
                        }
                }
                if (sortFunc != null)
                {
                    if (dir == "desc")
                    {
                        return rows.OrderByDescending(sortFunc).ToList();
                    }
                    else
                    {
                        return rows.OrderBy(sortFunc).ToList();
                    }
                }
            }

            return rows.ToList();
        }

        public static List<ListingModels.ListingItem> GetPartialList(int current, int rowCount, IEnumerable<ListingModels.ListingItem> rows)
        {
            int count = rows.Count();

            var partial = rowCount == -1 ? rows : rows.Skip((current - 1) * rowCount).Take(rowCount).ToList();

            return partial.ToList();
        }

    }
}
