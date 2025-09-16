using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class CompraDTO
    {
        [Required(ErrorMessage = "Debe ingresar el id del comprador")]
        public required int idComprador { get; set; }

        [Required(ErrorMessage = "Debe ingresar el id del vendedor")]
        public required int idVendedor { get; set; }

        [Required(ErrorMessage = "Debe ingresar el id de la moneda origen")]
        public required int idMonedaOrigen { get; set; }

        [Required(ErrorMessage = "Debe ingresar el id de la moneda destino")]
        public required int idMonedaDestino { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto de origen")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal MontoOrigen { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto de destino")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal MontoDestino { get; set; }

        [Required(ErrorMessage = "Debe ingresar la tasa acordada")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal TasaAcordada { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de compra")]
        public required DateTime FechaCompra { get; set; }

    }
}
