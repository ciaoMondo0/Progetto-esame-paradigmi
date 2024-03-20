using Microsoft.Extensions.Options;
using Progetto_paradigmi.Progetto.Application.Options;
using Progetto_paradigmi.Progetto.Models.Repositories;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Factories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Progetto_paradigmi.Progetto.Application.Services
{
    public class TokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        private readonly UtentiRepository _utentiRepository;
        private readonly UtentiFactory _utentiFactory;

        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, UtentiRepository _userRepository, UtentiFactory _utentiFactory)
        {
            this._utentiRepository = _userRepository;
            _jwtAuthOption = jwtAuthOption.Value;
            this._utentiFactory = _utentiFactory;
        }

        public string CreateToken(CreateTokenRequest request)
        {
            var user = _utentiRepository.GetUserByEmailAndPassword(request.Email, request.Password);
            if(user != null)
            {
                var claims = _utentiFactory.CreateClaimsToken(user);
                var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );
                var credentials = new SigningCredentials(securityKey
                    , SecurityAlgorithms.HmacSha256);

                var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                    , null
                    , claims
                    , expires: DateTime.Now.AddMinutes(30)
                    , signingCredentials: credentials
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                
                return token;

            } else
            {
                throw new Exception("Invalid email or password.");
            }
        }
    }
}
