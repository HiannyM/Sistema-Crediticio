using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class RegistroCarga
{
    public int IdRegistroCarga { get; set; }

    public int IdLote { get; set; }

    public string DetalleFila { get; set; } = null!;

    public string Resultado { get; set; } = null!;

    public string? MensajeError { get; set; }

    public virtual LoteCarga IdLoteNavigation { get; set; } = null!;
}
