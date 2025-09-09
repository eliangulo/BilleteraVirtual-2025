using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtual.Server.Components.Controller
{
    namespace BilleteraVirtual.API.Controllers
    {
        [ApiController]
        [Route("api/UsuariosController")]
        public class UsuariosController : ControllerBase
        {
            private readonly AppDbContext context;

            public UsuariosController(AppDbContext context)
            {
                this.context = context;
            }

           // api/Usuarios/register
            [HttpPost("registro")]
            public async Task<ActionResult>Registro(UsuariosRegistroDTO DTO)
            {
                // Validar que no se repita CUIL o correo
                var existe = await context.Usuarios.AnyAsync(u => u.CUIL == DTO.CUIL || u.Correo == DTO.Correo);
                if (existe)
                    return BadRequest("Existe un usuario con ese CUIL o correo.");

                var usuario = new Usuarios
                {
                    CUIL = DTO.CUIL,
                    Nombre = DTO.Nombre,
                    Apellido = DTO.Apellido,
                    Domicilio = DTO.Domicilio,
                    FechaNacimiento = DTO.FechaNacimiento,
                    Correo = DTO.Correo,
                    Telefono = DTO.Telefono,
                    EsAdmin = DTO.EsAdmin,
                    BilleteraId = 0
                };

                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();

                return Ok("Usuario registrado.");
            }

            //api/Usuarios/login
            [HttpPost("InicioDeSesion")]
            public async Task<ActionResult> Login(UsuariosLoginDTO DTO)
            {
                var usuario = await context.Usuarios
                    .FirstOrDefaultAsync(u => u.Correo == DTO.Correo && u.CUIL == DTO.CUIL);

                if (usuario == null)
                    return Unauthorized("Correo o CUIL incorrectos.");

                return Ok("Inicio de sesion exitosa");
              
            }

            //api/Usuarios/
            [HttpPut("{id:int}")]
            public async Task<ActionResult> PutUsuario(int id, UsuariosRegistroDTO DTO)
            {
                var usuario = await context.Usuarios.FindAsync(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado.");

                usuario.CUIL = DTO.CUIL;
                usuario.Nombre = DTO.Nombre;
                usuario.Apellido = DTO.Apellido;
                usuario.Domicilio = DTO.Domicilio;
                usuario.FechaNacimiento = DTO.FechaNacimiento;
                usuario.Correo = DTO.Correo;
                usuario.Telefono = DTO.Telefono;
                usuario.EsAdmin = DTO.EsAdmin;

                context.Entry(usuario).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok("Usuario actualizado correctamente.");
            }

            //api/Usuarios/5
            [HttpDelete("{id:int}")]
            public async Task<ActionResult> DeleteUsuario(int id)
            {
                var usuario = await context.Usuarios.FindAsync(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado.");

                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();

                return Ok("Usuario eliminado.");
            }
        }
    }
}
