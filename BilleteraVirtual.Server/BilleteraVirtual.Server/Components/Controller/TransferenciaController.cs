using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Transferencia")]
    public class TransferenciaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Transferencia> repositorio;

        public TransferenciaController(AppDbContext context, IRepositorio<Transferencia> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransferenciaCrearDTO>>> GetTransferenciaController()
        {
            var transferencia = await repositorio.Select();
            if (transferencia == null)
            {
                return NotFound("No se encontraron transferencias.");
            }
            if (transferencia.Count == 0)
            {
                return Ok("No existen transferencias");
            }
            return Ok(transferencia);
        }


        [HttpGet("{id:int}")] //api/transferencia/2
        public async Task<ActionResult<TransferenciaCrearDTO>> GetByID(int id)
        {
            var transferencia = await repositorio.SelectById(id);
            if (transferencia is null)
            {
                return NotFound($"No existe la transferencia con el id:{id}.");
            }

            return Ok(transferencia);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TransferenciaCrearDTO DTO)
        {
            try
            {
                var transferencia = new Transferencia
                {
                    IdCuentaOrigen = DTO.IdCuentaOrigen,
                    IdCuentaDestino = DTO.IdCuentaDestino,
                    Monto = DTO.Monto,
                    Comision = DTO.Comision,
                    descripcion = DTO.descripcion,
                    Fecha = DateTime.Now
                };


                await repositorio.Insert(transferencia);
                await context.SaveChangesAsync();
                return Ok(transferencia.Id);

            }
            catch (Exception e)
            {

                return BadRequest($"Error al crear transferencia: {e.Message}");
            }
        }

        [HttpPut("{id:int}")] //api/producto/2
        public async Task<ActionResult> Put(int id, Transferencia DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"Transferencia con el id:{id} ha sido cambiado de monto correctamente.");

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var transferencia = await context.Transferencias.FirstOrDefaultAsync(x => x.Id == id); ;
            if (transferencia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Transferencias.Remove(transferencia);
            await context.SaveChangesAsync();
            return Ok($"Producto con el id: {id} eliminado correctamente");

        }

    }
}
