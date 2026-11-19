using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly SnicRdContext _context;

        public RolesController(SnicRdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _context.Rols.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            var rol = await _context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound(new { mensaje = $"No se encontró ningún rol registrado con el ID {id}." });
            }

            return Ok(rol);
        }
    }
}
