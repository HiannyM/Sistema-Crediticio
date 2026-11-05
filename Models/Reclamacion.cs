using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Reclamacion
{
    public int IdReclamacion { get; set; }

    public int IdTitular { get; set; }

    public int? IdOperacion { get; set; }

    public string DescripcionReclamo { get; set; } = null!;

    public string? EstadoReclamo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateOnly FechaLimiteRespuesta { get; set; }

    public virtual ICollection<EvidenciaReclamacion> EvidenciaReclamacions { get; set; } = new List<EvidenciaReclamacion>();

    public virtual OperacionCredito? IdOperacionNavigation { get; set; }

    public virtual Titular IdTitularNavigation { get; set; } = null!;
}
