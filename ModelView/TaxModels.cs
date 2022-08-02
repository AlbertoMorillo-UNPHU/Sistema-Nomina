using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.ModelView
{
    public class TaxModels
    {
        public class Deductions
        {
            public decimal TaxableIncome { get; set; }
            public decimal ISR { get; set; }
            public decimal AFP { get; set; }
            public decimal ARS { get; set; }
            public decimal ARL { get; set; }
            public decimal TSS { get; set; }
            public decimal INFOTEP { get; set; }
            public decimal NetPay { get; set; }
        }
    }
}
