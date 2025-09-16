using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class ExtraccionDTO
    {
        public int CuentaID { get; set; }

        [Required(ErrorMessage = "El monto es requerido")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El habilitado es requerido")]
        public bool Habilitado { get; set; }
        [Required(ErrorMessage = "La fecha es requerido")]
        public DateTime Fecha { get; set; }
    }
}
