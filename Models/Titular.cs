using System;
using System.Collections.Generic;

namespace SNIC_RD.Models;

public partial class Titular
{
    public int IdTitular { get; set; }

    public string TipoTitular { get; set; } = null!;

    public string? Cedula { get; set; }

    public string? Rnc { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? RazonSocial { get; set; }

    public string? TelefonoCasa { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? TelefonoOficina { get; set; }

    public string Correo { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Consentimiento> Consentimientos { get; set; } = new List<Consentimiento>();

    public virtual ICollection<ConsultaCredito> ConsultaCreditos { get; set; } = new List<ConsultaCredito>();

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual ICollection<OperacionCredito> OperacionCreditos { get; set; } = new List<OperacionCredito>();

    public virtual ICollection<PuntajeCrediticio> PuntajeCrediticios { get; set; } = new List<PuntajeCrediticio>();

    public virtual ICollection<Reclamacion> Reclamacions { get; set; } = new List<Reclamacion>();

    public virtual ICollection<RegistroPagoAlternativo> RegistroPagoAlternativos { get; set; } = new List<RegistroPagoAlternativo>();
}
