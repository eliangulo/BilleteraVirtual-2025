using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface ITransferenciaRepositorio : IRepositorio<Transferencia>
    {
        Task<Transferencia?> SelectByIdCuentaDestino(int idCuentaDestino);
        Task<Transferencia?> SelectByIdCuentaOrigen(int idCuentaOrigen);
    }
}