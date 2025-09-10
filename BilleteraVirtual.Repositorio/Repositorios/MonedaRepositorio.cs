using BilleteraVirtual.BD.Datos;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public class MonedaRepositorio : Repositorio<Moneda>,
                                     IRepositorio<Moneda>,
                                     IMonedaRepositorio
    {
        private readonly AppDbContext context;

        public MonedaRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Moneda?> SelectByCodigoISO(string codISO)
        {
            try
            {
                Moneda? entidad = await context.Monedas.FirstOrDefaultAsync(x => x.CodISO.ToString() == codISO);
                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
