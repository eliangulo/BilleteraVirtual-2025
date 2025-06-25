using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.BD.Datos.Entidades
{ //Thomas

    public class Extraccion : EntityBase
    {
        // Clave foranea
        public int CuentaID { get; set; }
        public Cuenta? Cuenta { get; set; }


        [Required(ErrorMessage = "El monto es requerido")]
        [Column(TypeName = "decimal(18, 2)")]
        public required decimal Monto { get; set; }
        [Required(ErrorMessage = "El habilitado es requerido")]
        public required bool Habilitado { get; set; }
        [Required(ErrorMessage = "La fecha es requerido")]
        public required DateTime Fecha { get; set; }


    }
}
