using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface IUsuariosRepositorio<E> where E : class, IEntityBase
    {
        Task<int> Insert(E entidad);
        IQueryable<E> GetAll();
        Task<Usuarios?> SelectByCUIL(int cuil);
    }
}