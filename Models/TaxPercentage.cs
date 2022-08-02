using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaNomina.Models
{
    [Table("tTaxPercentage", Schema = "dbo")]
    public class TaxPercentage
    {
        [Key]
        public long Id { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Percent { get; set; }
    }
}
