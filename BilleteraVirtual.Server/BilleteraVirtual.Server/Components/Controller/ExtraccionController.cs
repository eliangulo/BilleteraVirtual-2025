using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;

namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Extraccion")]
    public class ExtraccionController : ControllerBase
    {
        private readonly IRepositorio<Extraccion> repositorio;

        public ExtraccionController(IRepositorio<Extraccion> repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
