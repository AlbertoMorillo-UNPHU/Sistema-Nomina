using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SistemaNomina.Models
{
    [Table("tEmployee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Nombres")]
        public string FirstName { get; set; }
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [NotMapped]
        public string NombreCompleto { get { return FirstName + " " + LastName; } }
        public string SSN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AFP { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ISR { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ARS { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RetirementPercent { get; set; }

        public string Direccion { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Puesto Desempeñado")]
        public string Puesto { get; set; }
        public DateTime CreateDateTime { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
