using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;    

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

        [HttpPost]
        public async Task<ActionResult<int>> Post(ExtraccionDTO DTO) 
        {
            try
            {
                Extraccion entidad = new Extraccion()
                {
                    CuentaID = DTO.CuentaID,
                    Monto = DTO.Monto,
                    Habilitado = DTO.Habilitado,
                    Fecha = DTO.Fecha
                };
                var id = await repositorio.Insert(entidad);
                return Ok(entidad.Id);

            }
            catch (Exception e)
            {

                return BadRequest($"Error al realizar la extraccion {e.Message}");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Extraccion>>> SelectFull() 
        {
            var lista = await repositorio.Select();
            if (lista == null || lista.Count == 0)
            {
                return NotFound("No se encontraron extracciones");
            }
            return Ok(lista);
        }
        [HttpGet]
        public async Task<ActionResult<Extraccion>> SelectById(int id) 
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound($"No se encontro la extraccion con id {id}");
            }
            return Ok(entidad);
        }
        [HttpGet]
        public async Task<ActionResult<List<Extraccion>>> ListaExtraccion() 
        {
            var lista = await repositorio.Select();
            var entidad = lista.Select(e => new ExtraccionListaDTO
            {
                Id = e.Id,
                Monto = e.Monto,
                Fecha = e.Fecha
            }).ToList();
            return Ok(entidad);
        }
    }
}
