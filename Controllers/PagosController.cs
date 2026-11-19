using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly SnicRdContext _context;

        public PagosController(SnicRdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPagos()
        {
            var pagos = await _context.Pagos.ToListAsync();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagoById(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound(new { mensaje = $"No se encontró ningún pago registrado con el ID {id}." });
            }

            return Ok(pago);
        }
    }
}
