using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.BD.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public class CompraRepositorio : Repositorio<Compra>, 
                                     IRepositorio<Compra>, 
                                     ICompraRepositorio
    {
        private readonly AppDbContext context;

        public CompraRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Compra?> SelectByIdComprador(int idComprador)
        {
            try
            {
                Compra? entidad = await context.Compras.FirstOrDefaultAsync(x => x.idComprador == idComprador);
                return entidad;
            }
            catch (Exception) { throw; }
        }
        public async Task<Compra?> SelectByIdVendedor(int idVendedor)
        {
            try
            {
                Compra? entidad = await context.Compras.FirstOrDefaultAsync(x => x.idVendedor == idVendedor);
                return entidad;
            }
            catch (Exception) { throw; }
        }
        public async Task<Compra?> SelectByIdMonedaOrigen(int idMonedaOrigen)
        {
            try
            {
                Compra? entidad = await context.Compras.FirstOrDefaultAsync(x => x.idMonedaOrigen == idMonedaOrigen);
                return entidad;
            }
            catch (Exception) { throw; }
        }
        public async Task<Compra?> SelectByIdMonedaDestino(int idMonedaDestino)
        {
            try
            {
                Compra? entidad = await context.Compras.FirstOrDefaultAsync(x => x.idMonedaDestino == idMonedaDestino);
                return entidad;
            }
            catch (Exception) { throw; }
        }

    }
}
