using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaNomina.Models
{
    [Table("tPayment", Schema = "dbo")]
    public class Payment
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Employee")]
        public long EmpId { get; set; }
        public decimal GrossPay { get; set; }
        public DateTime PaymentPeriodFrom { get; set; }
        public DateTime PaymentPeriodTo { get; set; }
        public decimal ISR { get; set; }
        public decimal AFP { get; set; }
        public decimal ARS { get; set; }
        public decimal ARL { get; set; }
        public decimal TSS { get; set; }
        public decimal INFOTEP { get; set; }
        public decimal Retirement { get; set; }
        public decimal NetPay { get; set; }
        public DateTime CreateDateTime { get; set; }
        
        // link to employee
        public virtual Employee Employee { get; set; }
    }
}
