using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Models
{
    public class HorasExtras
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Cantidad Horas")]
        public decimal CantidadMes { get; set; }

        [Display(Name = "Fecha Efectiva")]
        public DateTime FechaEfectiva { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }
        [ForeignKey("Payment")]
        public long PaymentId { get; set; }

        [Display(Name ="Salario")]
        public virtual Payment Payment { get; set; }

    }
}
