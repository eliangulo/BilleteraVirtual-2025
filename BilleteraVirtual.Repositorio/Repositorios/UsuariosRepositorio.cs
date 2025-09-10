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
    public class UsuariosRepositorio : Repositorio<Usuarios>,
                                      IRepositorio<Usuarios>,
                                      IUsuariosRepositorio
    {
        private readonly AppDbContext context;

        public UsuariosRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Usuarios?> SelectByCUIL(int cuil)
        {
            try
            {
                Usuarios? entidad = await context.Usuarios.FirstOrDefaultAsync(x => x.CUIL == cuil);
                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
