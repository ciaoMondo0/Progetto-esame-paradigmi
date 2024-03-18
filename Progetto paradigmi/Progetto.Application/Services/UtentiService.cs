using Progetto_paradigmi.Progetto.Models.Entities;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Models.Repositories;

namespace Progetto_paradigmi.Progetto.Application.Services
{


    public class UtentiService
    {
        private readonly UtentiRepository _userRepository;

        public UtentiService(UtentiRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(UtentiDTO userDto)
        {
            var newUser = new Utenti() { Name = userDto.Name, Surname = userDto.Surname, Email = userDto.Email, Password = userDto.Password, Id = userDto.Id };
            _userRepository.Aggiungi(newUser);
            _userRepository.Save();
        }
        
        public UtentiDTO GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            return new UtentiDTO { Email = user.Email, Name = user.Name, Surname = user.Surname, Password = user.Password };
        }

        public void UpdateUser(string email, UtentiDTO userDto)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException("L'utente non esiste.");
            }

            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Password = userDto.Password;
            _userRepository.Modifica(user);
            _userRepository.Save();
        }

        public void DeleteUser(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException("L'utente non esiste.");
            }

            _userRepository.Elimina(user);
            _userRepository.Save();
        }
        
    }



}

