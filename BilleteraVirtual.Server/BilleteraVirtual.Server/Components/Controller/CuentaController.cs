using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]  
        public async Task<ActionResult<List<CuentaDTO>>> GetMoneda()
        {
            var entidad = await repositorio.Select();
            var dtos = entidad.Select(e => new CuentaDTO
            {
                Id = e.Id,
                BilleteraId = e.BilleteraId,
                MonedaId = e.MonedaId,
                Moneda_Tipo = e.Moneda_Tipo,
                Saldo = e.Saldo

            }).ToList();
            return Ok(dtos);
        }

        [HttpGet("{Id:int}")] 
        public async Task<ActionResult<CuentaDTO>> GetById(int Id)
        {
            var cuenta = await repositorio.SelectById(Id);
            if (cuenta == null)
            {
                return NotFound($"Cuenta con Id {Id} no encontrada.");
            }
            var dto = new CuentaDTO
            {
                Id = cuenta.Id,
                BilleteraId = cuenta.BilleteraId,
                MonedaId = cuenta.MonedaId,
                Moneda_Tipo = cuenta.Moneda_Tipo,
                Saldo = cuenta.Saldo

            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CuentaDTO>> Create(CuentaDTO dto)
        {
            if (dto == null)
            {
                return BadRequest($"Datos no validos");
            }

            var existe = await repositorio.SelectById(dto.Id);
            if (existe != null)
            {
                return BadRequest($"Ya existe una moneda con el codigo ISO {dto.Id}");
            }

            var entidad = new Cuenta
            {
                BilleteraId = dto.BilleteraId,
                MonedaId = dto.MonedaId,
                Moneda_Tipo = dto.Moneda_Tipo,
                Saldo = dto.Saldo
            };

            var id = await repositorio.Insert(entidad);
            dto.Id = id;

            return CreatedAtAction(nameof(GetById), new {dto.Id}, dto);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Update(int Id, CuentaDTO dto)
        {
            var entidad = await repositorio.SelectById(Id);
            if (entidad == null)
            {
                return NotFound($"Cuenta con el Id {Id} no ha sido encontrada.");
            }

            entidad.BilleteraId = dto.BilleteraId;
            entidad.MonedaId = dto.MonedaId;
            entidad.Moneda_Tipo = dto.Moneda_Tipo;
            entidad.Saldo = dto.Saldo;

            var actualizado = await repositorio.Update(entidad.Id, entidad);
            if (!actualizado)
            {
                return BadRequest("No se pudo actualizar la Cuenta.");
            }

            return Ok("Cuenta actualizada correctamente.");
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var entidad = await repositorio.SelectById(Id);
            if (entidad == null)
            {
                return NotFound($"Cuenta con el id {Id} no ha sido encontrada.");
            }

            var eliminado = await repositorio.Existe(Id);
            if (!eliminado)
            {
                return NotFound($"Cuenta con id {Id} no se pudo eliminar.");
            }

            return Ok("Cuenta eliminada");
        }
    }
}
