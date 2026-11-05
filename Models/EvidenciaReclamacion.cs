using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class EvidenciaReclamacion
{
    public int IdEvidencia { get; set; }

    public int IdReclamacion { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public string RutaAlmacenamiento { get; set; } = null!;

    public DateTime? FechaSubida { get; set; }

    public virtual Reclamacion IdReclamacionNavigation { get; set; } = null!;
}
