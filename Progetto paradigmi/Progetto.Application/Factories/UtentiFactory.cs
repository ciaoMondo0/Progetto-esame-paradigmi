using Progetto_paradigmi.Progetto.Application.DTO;
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
                Id = dto.Id
            };
        }
    }
}
