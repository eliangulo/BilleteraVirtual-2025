using BilleteraVirtual.BD.Datos.Entidades;

namespace BilleteraVirtual.Repositorio.Repositorios
{
    public interface IMonedaRepositorio
    {
        Task<Moneda?> SelectByCodigoISO(string codISO);
    }
}