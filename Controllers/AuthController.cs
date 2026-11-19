using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNIC_RD.DTOs;
using SNIC_RD.Models;
using SNIC_RD.Services;

namespace SNIC_RD.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly SnicRdContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public AuthController(
        SnicRdContext context,
        ITokenService tokenService,
        IPasswordHasher<Usuario> passwordHasher)
    {
        _context = context;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    /// <summary>Valida credenciales y genera un token JWT.</summary>
    [HttpPost("login")]
    [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponse>> Login(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(
                item => item.Correo == request.Correo,
                cancellationToken);

        if (usuario is null || !await VerifyPasswordAsync(usuario, request.Contrasena, cancellationToken))
        {
            return Unauthorized(new { mensaje = "Correo o contraseña incorrectos." });
        }

        var (token, expiresAt) = _tokenService.CreateToken(usuario);
        return Ok(new LoginResponse(token, expiresAt));
    }

    private async Task<bool> VerifyPasswordAsync(
        Usuario usuario,
        string password,
        CancellationToken cancellationToken)
    {
        var storedPassword = usuario.Contrasena;
        if (IsIdentityPasswordHash(storedPassword))
        {
            var result = _passwordHasher.VerifyHashedPassword(usuario, storedPassword, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return false;
            }

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                usuario.Contrasena = _passwordHasher.HashPassword(usuario, password);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return true;
        }

        if (!CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(storedPassword),
                Encoding.UTF8.GetBytes(password)))
        {
            return false;
        }

        usuario.Contrasena = _passwordHasher.HashPassword(usuario, password);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static bool IsIdentityPasswordHash(string value)
    {
        try
        {
            var decoded = Convert.FromBase64String(value);
            return decoded.Length > 0 && (decoded[0] == 0x00 || decoded[0] == 0x01);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
