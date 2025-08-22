using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Business.Services.Interfaces;
using Store.Data.Repositories.Interfaces;
using Store.Entities.DTOs;
using Store.Entities.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Store.Business.Services
{
    public class AuthService : IAuthService
    {

        private readonly IGenericRepository<Clientes> _clientesRepo;
        private readonly string _jwtSecret;
        private readonly int _expiryHours;

        public AuthService(IGenericRepository<Clientes> clientesRepo, IConfiguration configuration)
        {
            _clientesRepo = clientesRepo;

            // Read values ​​from appsettings.json
            _jwtSecret = configuration["JwtSettings:Secret"];
            _expiryHours = int.Parse(configuration["JwtSettings:ExpiryHours"]);
        }

        public string Login(LoginDto loginDto)
        {
            // Search for a client by email
            var cliente = _clientesRepo.Find(c => c.Email == loginDto.Email).FirstOrDefault();
            if (cliente == null)
                return null;

            // Verify password with BCrypt
            bool passwordOk = BCrypt.Net.BCrypt.Verify(loginDto.Password, cliente.PasswordHash);
            if (!passwordOk)
                return null;

            // Create token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, cliente.ClienteId.ToString()),
                    new Claim(ClaimTypes.Name, cliente.Nombre)
                }),
                Expires = DateTime.UtcNow.AddHours(_expiryHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
