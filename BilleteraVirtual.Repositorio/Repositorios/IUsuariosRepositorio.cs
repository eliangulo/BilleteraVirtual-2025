using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface IUsuariosRepositorio
    {
        Task<Usuarios?> SelectByCUIL(int cuil);
    }
}