using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class HistorialAnualPago
{
    public int IdHistorialAnual { get; set; }

    public int IdOperacion { get; set; }

    public int Anio { get; set; }

    public decimal? TotalPagado { get; set; }

    public int? TotalAtrasos { get; set; }

    public decimal? MontoMaximoMora { get; set; }

    public virtual OperacionCredito IdOperacionNavigation { get; set; } = null!;
}
