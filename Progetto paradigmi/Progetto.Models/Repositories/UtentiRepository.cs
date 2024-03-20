using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Models.Context;
using Progetto_paradigmi.Progetto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_paradigmi.Progetto.Models.Repositories
{
    public class UtentiRepository : GenericRepository<Utenti>
    {

        private readonly List<Utenti> _users;

        public UtentiRepository(MyDbContext ctx) : base(ctx)
        {

        }

        
        public Utenti GetUserByEmail(string email)
        {
            return _ctx.User.Where(u => u.Email == email).FirstOrDefault();

        }

        public Utenti GetUserByEmailAndPassword(string email, string password)
        {
            return _ctx.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public Utenti GetById(int id)
        {
            return _ctx.User.Where(u => u.Id == id).FirstOrDefault();
        }




    }
}
