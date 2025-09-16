using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class DepositoDTO
    {
        public int CuentaId { get; set; }
        public decimal Monto { get; set; }
        public bool HabilitadO { get; set; }
        public DateTime Fecha { get; set; }

    }
}
