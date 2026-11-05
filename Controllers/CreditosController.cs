using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        private readonly SnicRdContext _context;

        public CreditosController(SnicRdContext context)
        {
            _context = context;
        }

        [HttpGet("titular/{idTitular}")]
        public async Task<IActionResult> GetCreditosByTitular(int idTitular)
        {
            var operaciones = await _context.OperacionCreditos
                .Where(o => o.IdTitular == idTitular)
                .ToListAsync();

            if (!operaciones.Any())
                return NotFound(new { mensaje = "No se encontraron operaciones de crédito para este titular." });

            return Ok(operaciones);
        }
    }
}
