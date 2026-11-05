using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class EntidadReportante
{
    public int IdEntidad { get; set; }

    public string NombreEntidad { get; set; } = null!;

    public string TipoEntidad { get; set; } = null!;

    public string? RncEntidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Consentimiento> Consentimientos { get; set; } = new List<Consentimiento>();

    public virtual ICollection<ConsultaCredito> ConsultaCreditos { get; set; } = new List<ConsultaCredito>();

    public virtual ICollection<LoteCarga> LoteCargas { get; set; } = new List<LoteCarga>();

    public virtual ICollection<OperacionCredito> OperacionCreditos { get; set; } = new List<OperacionCredito>();
}
