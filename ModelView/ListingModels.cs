using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.ModelView
{
    public class ListingModels
    {
        public class ListingRequest
        {
            public long? EmpId { get; set; }
            public string State { get; set; }
            public DateTime? PayPostingFrom { get; set; }
            public DateTime? PayPostingTo { get; set; }

            public int Current { get; set; }
            public int RowCount { get; set; }
            public string SearchPhrase { get; set; }

            public Dictionary<string, string> Sort { get; set; }
        }

        public class ListingResult
        {
            public int Current { get; set; }
            public int RowCount { get; set; }
            public int Total { get; set; }

            public IEnumerable<ListingItem> Rows { get; set; }
        }

        public class ListingItem
        {
            public long EmpId { get; set; }
            public string FullName { get; set; }
            public string State { get; set; }
            public string LastPaymentDate { get; set; }
            public string LastPaymentAmount { get; set; }
            public string YtdPay { get; set; }
        }

        public class ViewModel
        {
            public IEnumerable<DropdownListItem> EmplList { get; set; }
            public IEnumerable<DropdownListItem> StatesList { get; set; }
        }
    }
}
