using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.BD.Datos.Entidades
{  //Jazmin
    public class Deposito : EntityBase
    {
        //Clave foranea de Cuenta
        [Required(ErrorMessage = "La Cuenta es requerida")]
        public required int CuentaId { get; set; }
        public Cuenta? Cuenta { get; set; }

        //

        [Required(ErrorMessage = "El Monto es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Monto { get; set; }

        //

        [Required(ErrorMessage = "Es requerido")]
        public required bool HabilitadO { get; set; }

        //

        [Required(ErrorMessage = "La Fecha es requerida")]
        public required DateTime Fecha { get; set; }

    }
}
