using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;

namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Deposito")]
    public class DepositoController : ControllerBase
    {
        private readonly IRepositorio<Deposito> repositorio;

        public DepositoController(IRepositorio<Deposito> repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
