using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public class TransferenciaRepositorio : Repositorio<Transferencia>, 
                                            IRepositorio<Transferencia>, 
                                            ITransferenciaRepositorio
    {
        private readonly AppDbContext context;

        public TransferenciaRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Transferencia?> SelectByIdCuentaOrigen(int idCuentaOrigen)
        {
            try
            {
                Transferencia? entidad = await context.Transferencias.FirstOrDefaultAsync(x => x.IdCuentaOrigen == idCuentaOrigen);
                return entidad;
            }
            catch (Exception) { throw; }
        }
        public async Task<Transferencia?> SelectByIdCuentaDestino(int idCuentaDestino)
        {
            try
            {
                Transferencia? entidad = await context.Transferencias.FirstOrDefaultAsync(x => x.IdCuentaDestino == idCuentaDestino);
                return entidad;
            }
            catch (Exception) { throw; }
        }
    }
}
