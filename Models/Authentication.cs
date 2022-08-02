using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Models
{
    [Table("tAuthentication", Schema = "dbo")]
    public class Authentication
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public Guid AuthKey { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
