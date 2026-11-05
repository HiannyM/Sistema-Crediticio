using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class HistorialCrediticio
{
    public int IdHistorial { get; set; }

    public int IdOperacion { get; set; }

    public DateOnly MesReporte { get; set; }

    public int? DiasMora { get; set; }

    public decimal MontoCuota { get; set; }

    public string EstadoCuota { get; set; } = null!;

    public virtual OperacionCredito IdOperacionNavigation { get; set; } = null!;
}
