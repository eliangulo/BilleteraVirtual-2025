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
    public class UsuariosRepositorio<E> : IUsuariosRepositorio<E> where E : class, IEntityBase
    {
        private readonly AppDbContext context;

        public UsuariosRepositorio(AppDbContext context)
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
        public async Task<int> Insert(E entidad)
        {
            await context.Set<E>().AddAsync(entidad);
            await context.SaveChangesAsync();

            // Busca la propiedad Id si existe y la devuelve
            var propiedadId = entidad?.GetType().GetProperty("Id");
            if (propiedadId != null)
            {
                return (int)(propiedadId.GetValue(entidad) ?? 0);
            }

            return 0;
        }

        public IQueryable<E> GetAll()
        {
            return context.Set<E>().AsQueryable();
        }
    }
}
