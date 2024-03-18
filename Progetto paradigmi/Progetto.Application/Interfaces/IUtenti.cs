using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Application.Interfaces
{
    public interface IUtenti
    {
        Utenti Register(Utenti user);
        Utenti Authenticate(string email, string password);
    }
}
