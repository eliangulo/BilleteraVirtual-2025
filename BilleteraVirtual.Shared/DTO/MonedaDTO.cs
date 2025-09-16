using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class MonedaDTO
    {
        public string TipoMoneda { get; set; } = "";
        public bool Habilitada { get; set; }
        public int CodISO { get; set; }
    }
}
