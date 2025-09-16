using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class UsuariosRegistroDTO
    {
        [Key]
        public int CUIL { get; set; }//pk
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool EsAdmin { get; set; } = false;
    }
}
