using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SistemaNomina.Models
{
    [Table("tPayment", Schema = "dbo")]
    public class Payment
    {
        [Key]
        [DisplayName("Empleado")]
        public long Id { get; set; }
        [ForeignKey("Employee")]
        public long EmpId { get; set; }
        [DisplayName("Pago Sin Deducciones")]
        public decimal GrossPay { get; set; }
        [DisplayName("Inicio Periodo")]
        public DateTime PaymentPeriodFrom { get; set; }
        [DisplayName("Fin Periodo")]
        public DateTime? PaymentPeriodTo { get; set; }
        public decimal ISR { get; set; }
        public decimal AFP { get; set; }
        public decimal ARS { get; set; }
        public decimal ARL { get; set; }
        public decimal TSS { get; set; }
        public decimal INFOTEP { get; set; }
        public decimal Retirement { get; set; }
        [DisplayName("Pago Neto")]
        public decimal NetPay { get; set; }
        [DisplayName("Fecha Creacion")]
        public DateTime CreateDateTime { get; set; }
        
        [DisplayName("Empleado")]
        public virtual Employee Employee { get; set; }
    }
}
