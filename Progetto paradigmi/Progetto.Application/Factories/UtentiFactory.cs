using Microsoft.Graph.Models;
using Progetto_paradigmi.Progetto.Application.DTO;
using System.Security.Claims;

using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Application.Factories
{
    public class UtentiFactory
    {

        public Utenti CreateUser(UtentiDTO dto)
        {
            return new Utenti()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Password = dto.Password,
                
            };
        }

        public List<Claim> CreateClaimsToken(Utenti utenti)
        {
        return new List<Claim>
    {
          
        new Claim("Id", utenti.Id.ToString()),
        new Claim("Email", utenti.Email),
        new Claim("Nome", utenti.Name),
        new Claim("Cognome", utenti.Surname),
        
    };
        }
    }
}
