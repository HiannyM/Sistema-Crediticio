using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Consentimiento
{
    public int IdConsentimiento { get; set; }

    public int IdTitular { get; set; }

    public int IdEntidad { get; set; }

    public string Proposito { get; set; } = null!;

    public string? EstadoConsentimiento { get; set; }

    public DateTime? FechaOtorgamiento { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public virtual EntidadReportante IdEntidadNavigation { get; set; } = null!;

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
