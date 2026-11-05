using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdOperacion { get; set; }

    public decimal MontoPagado { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? CanalPago { get; set; }

    public virtual OperacionCredito IdOperacionNavigation { get; set; } = null!;
}
