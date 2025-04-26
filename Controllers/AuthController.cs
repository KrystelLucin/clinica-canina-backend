using ClinicaCanina.API.Data;
using ClinicaCanina.API.DTOs;
using ClinicaCanina.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicaCanina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ClinicaContext _context;
        private readonly IConfiguration _config;

        public AuthController(ClinicaContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var existe = await _context.Usuarios
                .AnyAsync(u => u.NombreUsuario == request.NombreUsuario);

            if (existe)
                return BadRequest("El nombre de usuario ya existe.");

            var nuevo = new Usuario
            {
                NombreUsuario = request.NombreUsuario,
                Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena),
                CreatedAt = DateTime.UtcNow
            };

            _context.Usuarios.Add(nuevo);
            await _context.SaveChangesAsync();

            return Ok("Usuario registrado correctamente.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario && u.DeletedAt == null);

            if (user == null)
                return Unauthorized("Usuario no encontrado");

            if (user.Bloqueado)
                return Unauthorized("Tu cuenta ha sido bloqueada. Contacta al administrador.");

            if (!BCrypt.Net.BCrypt.Verify(request.Contrasena, user.Contrasena))
            {
                user.IntentosFallidos++;
                if (user.IntentosFallidos >= 3)
                    user.Bloqueado = true;

                user.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Unauthorized("Contraseña incorrecta.");
            }

            user.IntentosFallidos = 0;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim(ClaimTypes.Role, "usuario") 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
