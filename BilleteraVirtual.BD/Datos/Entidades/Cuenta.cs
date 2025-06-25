using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.BD.Datos.Entidades
{ //Thomas

    [Index(nameof(Moneda_Tipo), Name = "Cuenta_Moneda_Tipo_UQ", IsUnique = true)]
    public class Cuenta : EntityBase
    {

        // Clave foranea
        public required int BilleteraId { get; set; }
        public Billetera? Billetera { get; set; }

        [Required(ErrorMessage = "La moneda id es requerido")]
        public required int MonedaId { get; set; }
        public Moneda? Moneda { get; set; }


        [Required(ErrorMessage = "Debe ingresar el tipo moneda")]        
        public required string Moneda_Tipo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public required decimal Saldo { get; set; }

 
    }
}
