using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;


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

        [HttpGet] 
        public async Task<ActionResult<List<DepositoIdDTO>>> GetDepositos()
        {
            var entidad = await repositorio.Select();
            var dtos = entidad.Select(e => new DepositoIdDTO
            {
                Id = e.Id,
                CuentaId = e.CuentaId,
                Monto = e.Monto,
                HabilitadO = e.HabilitadO,
                Fecha = e.Fecha

            }).ToList();

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<DepositoIdDTO>> Create(DepositoDTO dto)
        {
            if (dto == null)
            {
                return BadRequest($"Datos no validos");
            }

            var entidad = new Deposito
            {
                CuentaId = dto.CuentaId,
                Monto = dto.Monto,
                HabilitadO = dto.HabilitadO,
                Fecha = dto.Fecha
            };  

            var id = await repositorio.Insert(entidad);
            var dep = new DepositoIdDTO
            {
                Id = id,
                CuentaId = dto.CuentaId,
                Monto = dto.Monto,
                HabilitadO = dto.HabilitadO,
                Fecha = dto.Fecha
            };

            return CreatedAtAction(nameof(GetDepositos), new {dep.Id}, dep);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Update(int Id, DepositoDTO dto)
        {
            var entidad = await repositorio.SelectById(Id);
            if (entidad == null)
            {
                return NotFound($"Deposito con el id {Id} no fue encontrada.");
            }

            entidad.CuentaId = dto.CuentaId;
            entidad.Monto = dto.Monto;
            entidad.HabilitadO = dto.HabilitadO;
            entidad.Fecha = dto.Fecha;

            var actualizado = await repositorio.Update(Id, entidad);
            if (!actualizado)
            {
                return BadRequest("No se pudo actualizar el deposito.");
            }

            return Ok("Deposito actualizado correctamente.");
        }
    }
}
