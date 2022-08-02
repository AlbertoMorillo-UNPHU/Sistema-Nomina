using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaNomina.Models
{
    [Table("tEmployee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AFP { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ISR { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ARS { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RetirementPercent { get; set; }
        public DateTime CreateDateTime { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
