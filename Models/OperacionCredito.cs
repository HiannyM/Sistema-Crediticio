using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class OperacionCredito
{
    public int IdOperacion { get; set; }

    public int IdTitular { get; set; }

    public int IdEntidad { get; set; }

    public string TipoProducto { get; set; } = null!;

    public decimal MontoOriginal { get; set; }

    public decimal BalanceActual { get; set; }

    public string EstadoOperacion { get; set; } = null!;

    public DateOnly FechaOtorgamiento { get; set; }

    public DateOnly? FechaUltimoPago { get; set; }

    public virtual ICollection<HistorialAnualPago> HistorialAnualPagos { get; set; } = new List<HistorialAnualPago>();

    public virtual ICollection<HistorialCrediticio> HistorialCrediticios { get; set; } = new List<HistorialCrediticio>();

    public virtual EntidadReportante IdEntidadNavigation { get; set; } = null!;

    public virtual Titular IdTitularNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Reclamacion> Reclamacions { get; set; } = new List<Reclamacion>();
}
