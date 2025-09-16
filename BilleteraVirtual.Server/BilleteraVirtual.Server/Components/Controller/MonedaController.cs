using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;


namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Moneda")]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaRepositorio repositorio;
        private readonly IRepositorio<Moneda> rep;
        public MonedaController(IMonedaRepositorio repositorio, IRepositorio<Moneda> rep)
        {
            this.repositorio = repositorio;
            this.rep= rep;
        }

        //Este Crud depende se hace con el codigo ISO de la moneda
        //para mi se usaria mas que el ID 

        [HttpGet]   //consulta todas las monedas 
        public async Task<ActionResult<List<MonedaDTO>>> GetMoneda()
        {
            var entidad = await rep.Select();
            var dtos = entidad.Select(e => new MonedaDTO
            {
                Id = e.Id,
                TipoMoneda = e.TipoMoneda,
                Habilitada = e.Habilitada,
                CodISO = e.CodISO   

            }).ToList();   
            return Ok(dtos);
        }

        [HttpGet("{CodISO:int}")]   //consulta todas las monedas por el CodigoISO
        public async Task<ActionResult<MonedaDTO>> GetByCodigoISO(int CodISO)
        {
            var moneda = await repositorio.SelectByCodigoISO(CodISO.ToString());
            if (moneda == null)
            {
                return NotFound($"Moneda con codigo ISO {CodISO} no encontrada.");
            }
            var dto = new MonedaDTO
            {
                Id = moneda.Id,
                TipoMoneda = moneda.TipoMoneda,
                Habilitada = moneda.Habilitada,
                CodISO = moneda.CodISO
            };
            return Ok(dto);
        }

        [HttpPost] 
        public async Task<ActionResult<MonedaDTO>> Create(MonedaDTO dto)
        {
            if (dto == null)
            {
                return BadRequest($"Datos no validos");
            }

            var existe = await repositorio.SelectByCodigoISO(dto.CodISO.ToString());  
            if (existe != null)
            {
                return BadRequest($"Ya existe una moneda con el codigo ISO {dto.CodISO}");
            }   

            var entidad = new Moneda
            {
                TipoMoneda = dto.TipoMoneda,
                Habilitada = dto.Habilitada,
                CodISO = dto.CodISO
            };

            var id = await rep.Insert(entidad); 
            dto.Id = id;

            return CreatedAtAction(nameof(GetByCodigoISO), new {dto.CodISO}, dto);
        }

        [HttpPut("{CodISO:int}")]
        public async Task<ActionResult> Update(int CodISO, MonedaDTO dto) 
        {
            var entidad = await repositorio.SelectByCodigoISO(CodISO.ToString());
            if (entidad == null)
            {
                return NotFound($"Moneda con codigo ISO {CodISO} no encontrada.");
            }

            entidad.TipoMoneda = dto.TipoMoneda;
            entidad.Habilitada = dto.Habilitada;
            entidad.CodISO = dto.CodISO;

            var actualizado = await rep.Update(entidad.Id, entidad);    
            if (!actualizado)
            {
                return BadRequest("No se pudo actualizar la moneda.");
            }   

            return Ok("Moneda actualizada correctamente.");
        }

        [HttpDelete("{CodISO:int}")]   
        public async Task<ActionResult> Delete(int CodISO)
        {
            var entidad = await repositorio.SelectByCodigoISO(CodISO.ToString());   
            if (entidad == null)
            {
                return NotFound($"Moneda con codigo ISO {CodISO} no encontrada.");
            }

            var eliminado = await rep.Existe(CodISO);
            if (!eliminado)
            {
                return NotFound($"Moneda con id {CodISO} no se pudo eliminar.");
            }

            return Ok("Moneda eliminada");
        }
    }
}
