using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class ProveedorAlternativo
{
    public int IdProveedor { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public string TipoServicio { get; set; } = null!;

    public string RncProveedor { get; set; } = null!;

    public virtual ICollection<RegistroPagoAlternativo> RegistroPagoAlternativos { get; set; } = new List<RegistroPagoAlternativo>();
}
