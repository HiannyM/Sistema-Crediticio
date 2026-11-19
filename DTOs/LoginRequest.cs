using System.ComponentModel.DataAnnotations;

namespace SNIC_RD.DTOs;

/// <summary>Credenciales para iniciar sesión en la API.</summary>
public sealed record LoginRequest
{
    /// <summary>Correo electrónico registrado para el usuario.</summary>
    [Required, EmailAddress]
    public required string Correo { get; init; }

    /// <summary>Contraseña del usuario.</summary>
    [Required]
    public required string Contrasena { get; init; }
}
