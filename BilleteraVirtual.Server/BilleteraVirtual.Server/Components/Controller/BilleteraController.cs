using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;

namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Billetera")]
    public class BilleteraController : ControllerBase
    {
        private readonly IRepositorio<Billetera> repositorio;

        public BilleteraController(IRepositorio<Billetera> repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
