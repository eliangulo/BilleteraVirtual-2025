using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class TransferenciaCrearDTO
    {
        [Required(ErrorMessage = "Debe ingresar la fecha")]
        public required DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Monto { get; set; }

        [Required(ErrorMessage = "Debe ingresar la comision")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Comision { get; set; }

        [Required(ErrorMessage = "Debe ingresar el ID de la cuenta origen")]
        public required int IdCuentaOrigen { get; set; }

        [Required(ErrorMessage = "Debe ingresar el ID de la cuenta destino")]
        public required int IdCuentaDestino { get; set; }
        public string descripcion { get; set; } = "";

    }
}
