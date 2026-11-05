using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class BitacoraAuditorium
{
    public int IdBitacora { get; set; }

    public int? IdUsuario { get; set; }

    public string Accion { get; set; } = null!;

    public string TablaAfectada { get; set; } = null!;

    public int? RegistroId { get; set; }

    public string DireccionIp { get; set; } = null!;

    public DateTime? FechaAccion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
