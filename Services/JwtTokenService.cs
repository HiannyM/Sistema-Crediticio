using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SNIC_RD.Models;

namespace SNIC_RD.Services;

public interface ITokenService
{
    (string Token, DateTimeOffset ExpiresAt) CreateToken(Usuario usuario);
}

public sealed class JwtTokenService : ITokenService
{
    private readonly SigningCredentials _credentials;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expirationMinutes;

    public JwtTokenService(IConfiguration configuration)
    {
        var key = configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("Configure Jwt:Key.");
        _issuer = configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("Configure Jwt:Issuer.");
        _audience = configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("Configure Jwt:Audience.");
        _expirationMinutes = configuration.GetValue<int?>("Jwt:AccessTokenExpirationMinutes") ?? 3;
        _credentials = new SigningCredentials(
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256);
    }

    public (string Token, DateTimeOffset ExpiresAt) CreateToken(Usuario usuario)
    {
        var now = DateTimeOffset.UtcNow;
        var expiresAt = now.AddMinutes(_expirationMinutes);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
            new Claim(ClaimTypes.Name, usuario.NombreUsuario),
            new Claim("idRol", usuario.IdRol.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            notBefore: now.UtcDateTime,
            expires: expiresAt.UtcDateTime,
            signingCredentials: _credentials);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }
}
