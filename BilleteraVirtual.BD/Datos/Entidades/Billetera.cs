using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.BD.Datos.Entidades
{//Lucas
    // Unique
    
    public class Billetera : EntityBase
    {
        [Required(ErrorMessage = "La Fecha es requerido")]
        public required DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El rol billetera es requerido")]
        public required bool Billera_Admin { get; set; }

    }
}
