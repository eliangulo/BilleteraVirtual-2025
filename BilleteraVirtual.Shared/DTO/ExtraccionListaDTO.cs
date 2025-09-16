using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class ExtraccionListaDTO
    {
        public int Id { get; set; }
        public  decimal Monto { get; set; }
        public  DateTime Fecha { get; set; }
    }
}
