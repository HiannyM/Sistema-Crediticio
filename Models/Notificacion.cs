using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int IdTitular { get; set; }

    public string TipoNotificacion { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public bool? Leido { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
