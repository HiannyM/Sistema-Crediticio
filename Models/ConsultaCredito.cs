using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class ConsultaCredito
{
    public int IdConsulta { get; set; }

    public int IdTitular { get; set; }

    public int IdEntidad { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public string Proposito { get; set; } = null!;

    public virtual EntidadReportante IdEntidadNavigation { get; set; } = null!;

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
