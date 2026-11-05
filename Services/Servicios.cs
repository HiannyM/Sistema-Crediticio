using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Services
{
    public interface ICreditoService
    {
        Task<object?> ObtenerReporteCrediticioAsync(string cedulaOrRnc);
    }

    public class CreditoService : ICreditoService
    {
        private readonly SnicRdContext _context;

        public CreditoService(SnicRdContext context)
        {
            _context = context;
        }

        public async Task<object?> ObtenerReporteCrediticioAsync(string cedulaOrRnc)
        {
            var titular = await _context.Titulars
                .Include(t => t.OperacionCreditos)
                .ThenInclude(o => o.HistorialAnualPagos)
                .FirstOrDefaultAsync(t => t.Cedula == cedulaOrRnc || t.Rnc == cedulaOrRnc);

            if (titular == null) return null;

            // Retorna la estructura consolidada para el reporte
            return new
            {
                Titular = titular.Nombre + " " + (titular.Apellido ?? titular.RazonSocial),
                Documento = titular.Cedula ?? titular.Rnc,
                Operaciones = titular.OperacionCreditos
            };
        }
    }
}
