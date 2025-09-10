using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;

namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Cuenta")]
    public class CuentaController : ControllerBase
    {
        private readonly IRepositorio<Cuenta> repositorio;

        public CuentaController(IRepositorio<Cuenta> repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
