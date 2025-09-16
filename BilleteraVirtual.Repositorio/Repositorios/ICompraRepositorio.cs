using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface ICompraRepositorio : IRepositorio<Compra>
    {
        Task<Compra?> SelectByIdComprador(int idComprador);
        Task<Compra?> SelectByIdMonedaDestino(int idMonedaDestino);
        Task<Compra?> SelectByIdMonedaOrigen(int idMonedaOrigen);
        Task<Compra?> SelectByIdVendedor(int idVendedor);
    }
}