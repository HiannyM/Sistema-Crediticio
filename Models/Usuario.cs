
using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<BitacoraAuditorium> BitacoraAuditoria { get; set; } = new List<BitacoraAuditorium>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
