namespace SNIC_RD.DTOs;

/// <summary>Token de acceso y momento de expiración.</summary>
public sealed record LoginResponse(string Token, DateTimeOffset ExpiraEn);
