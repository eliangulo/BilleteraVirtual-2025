using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosRepositorio<Usuarios> repositorio;
    private readonly AppDbContext context;

    public UsuariosController(AppDbContext context,
        IUsuariosRepositorio<Usuarios> repositorio)
    {
        this.repositorio = repositorio;
        this.context = context;
    }

    // POST: api/usuarios/registro
    [HttpPost("registro")]
    public async Task<ActionResult<int>> RegistrarUsuario(UsuariosRegistroDTO DTO)
    {
        try
        {
            var billetera = new Billetera
            {
                // inicializá lo que tu entidad Billetera necesite
                FechaCreacion = DateTime.Now,
                Billera_Admin = DTO.EsAdmin
            };

            await context.Billeteras.AddAsync(billetera);
            await context.SaveChangesAsync(); // guarda y asigna Id a la billetera

            Usuarios usuario = new Usuarios
            {
                BilleteraId = billetera.Id, // Asignar un valor predeterminado o manejarlo según la lógica de negocio
                CUIL = DTO.CUIL,
                Nombre = DTO.Nombre,
                Apellido = DTO.Apellido,
                Domicilio = DTO.Domicilio,
                FechaNacimiento = DTO.FechaNacimiento,
                Correo = DTO.Correo,
                Telefono = DTO.Telefono,
                EsAdmin = DTO.EsAdmin
            };

            await repositorio.Insert(usuario);
            return Ok(usuario.Id); //usario
        }
        catch (Exception e)
        {
            return BadRequest($"Error al crear el registro: {e.InnerException?.Message ?? e.Message}");
        }
    }

    // POST: api/usuarios/inicio-sesion
    [HttpPost("inicio-sesion")]
    public async Task<ActionResult> IniciarSesion(UsuariosLoginDTO DTO)
    {
        try
        {
            var usuario = await repositorio.GetAll()
                .Where(u => u.Correo == DTO.Correo && u.CUIL == DTO.CUIL)
                .FirstOrDefaultAsync();

            if (usuario == null)
                return Unauthorized("CUIL o correo incorrecto.");

            return Ok(new
            {
                usuario.CUIL,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo
            });
        }
        catch (Exception e)
        {
            return BadRequest($"Error al iniciar sesión: {e.Message}");
        }
    }
}