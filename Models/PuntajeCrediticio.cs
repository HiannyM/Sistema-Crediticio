using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class PuntajeCrediticio
{
    public int IdPuntaje { get; set; }

    public int IdTitular { get; set; }

    public int Puntaje { get; set; }

    public DateTime? FechaCalculo { get; set; }

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
