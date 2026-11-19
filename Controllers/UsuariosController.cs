using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SnicRdContext _context;

        public UsuariosController(SnicRdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Select(usuario => new
                {
                    usuario.IdUsuario,
                    usuario.IdRol,
                    usuario.NombreUsuario,
                    usuario.Correo,
                    usuario.FechaCreacion
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = $"No se encontró ningún usuario registrado con el ID {id}." });
            }

            return Ok(new
            {
                usuario.IdUsuario,
                usuario.IdRol,
                usuario.NombreUsuario,
                usuario.Correo,
                usuario.FechaCreacion
            });
        }
    }
}
