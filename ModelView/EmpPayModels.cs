using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.ModelView
{
    public class EmpPayModels
    {
        
        public class EmpAddUpdateFeedback
        {
            public long EmpId { get; set; }
            public string Errors { get; set; }
            public bool Success { get; set; }
        }

        public class PaymentFeedback
        {
            public long EmpId { get; set; }
            public string Errors { get; set; }
            public bool Success { get; set; }
        }
    }
}
