using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class RegistroPagoAlternativo
{
    public int IdPagoAlternativo { get; set; }

    public int IdTitular { get; set; }

    public int IdProveedor { get; set; }

    public decimal Monto { get; set; }

    public DateOnly FechaFacturacion { get; set; }

    public string EstadoPago { get; set; } = null!;

    public virtual ProveedorAlternativo IdProveedorNavigation { get; set; } = null!;

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
