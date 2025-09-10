using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface ITransferenciaRepositorio
    {
        Task<Transferencia?> SelectByIdCuentaDestino(int idCuentaDestino);
        Task<Transferencia?> SelectByIdCuentaOrigen(int idCuentaOrigen);
    }
}