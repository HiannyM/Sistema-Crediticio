using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitularesController : ControllerBase
    {
        private readonly SnicRdContext _context;

        public TitularesController(SnicRdContext context)
        {
            _context = context;
        }

        // GET: api/titulares/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitularById(int id)
        {
            // Busca el titular utilizando la llave primaria
            var titular = await _context.Titulars.FindAsync(id);

            // Si no existe, retorna un código HTTP 404 Not Found con un mensaje claro
            if (titular == null)
            {
                return NotFound(new { mensaje = $"No se encontró ningún titular registrado con el ID {id}." });
            }

            // Si lo encuentra, retorna un código HTTP 200 OK con los datos del titular en formato JSON
            return Ok(titular);
        }
    }
}
