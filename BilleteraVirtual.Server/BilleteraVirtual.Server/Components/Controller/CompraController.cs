using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BilleteraVirtual.Server.Components.Controller
{
    [ApiController]
    [Route("api/Compra")]    
        public class CompraController : ControllerBase
        {
        private readonly AppDbContext context;
        private readonly IRepositorio<Compra> repositorio;

            public CompraController(AppDbContext context, IRepositorio<Compra> repositorio)
            {
                this.repositorio = repositorio;
                this.context = context;
        }

        [HttpGet("{id:int}")] //api/compra/2
        public async Task<ActionResult<Compra>> SelectById(int id)
        {
            var compra = await repositorio.SelectById(id);
            if (compra is null)
            {
                return NotFound($"No existe la compra con el id:{id}.");
            }

            return Ok(compra);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CompraDTO DTO)
        {
            try
            {
                var compra = new Compra
                {
                    idComprador = DTO.idComprador,
                    idVendedor = DTO.idVendedor,
                    idMonedaOrigen = DTO.idMonedaOrigen,
                    idMonedaDestino = DTO.idMonedaDestino,
                    MontoOrigen = DTO.MontoOrigen,
                    MontoDestino = DTO.MontoDestino,
                    TasaAcordada = DTO.TasaAcordada,
                    FechaCompra = DTO.FechaCompra

                };
                
                await repositorio.Insert(compra);
                await context.SaveChangesAsync();
                return Ok(compra.Id);

            }
            catch (Exception e)
            {

                return BadRequest($"Error al crear transferencia: {e.Message}");
            }
        }




    }


}
