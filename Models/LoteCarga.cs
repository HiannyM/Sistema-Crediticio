using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class LoteCarga
{
    public int IdLote { get; set; }

    public int IdEntidad { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public DateTime? FechaCarga { get; set; }

    public int TotalRegistros { get; set; }

    public int RegistrosExitosos { get; set; }

    public int RegistrosRechazados { get; set; }

    public string EstadoLote { get; set; } = null!;

    public virtual EntidadReportante IdEntidadNavigation { get; set; } = null!;

    public virtual ICollection<RegistroCarga> RegistroCargas { get; set; } = new List<RegistroCarga>();
}
