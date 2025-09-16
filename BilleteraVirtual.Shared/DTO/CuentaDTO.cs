using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Shared.DTO
{
    public class CuentaDTO
    {
        public int Id { get; set; }
        public int BilleteraId { get; set; }
        public int MonedaId { get; set; }
        public string Moneda_Tipo { get; set; } = "";
        public decimal Saldo { get; set; }
    }
}
