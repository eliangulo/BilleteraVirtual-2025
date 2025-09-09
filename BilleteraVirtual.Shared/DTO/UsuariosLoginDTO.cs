using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class UsuariosLoginDTO
    {
        public string Correo { get; set; } = null!;
        public int CUIL { get; set; }
        
    }
}
