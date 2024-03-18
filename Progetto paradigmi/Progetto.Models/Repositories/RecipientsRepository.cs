using Progetto_paradigmi.Progetto.Models.Context;

using Progetto_paradigmi.Progetto.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_paradigmi.Progetto.Models.Repositories
{

    public class RecipientsRepository : GenericRepository<Recipients>
{
        public RecipientsRepository(MyDbContext ctx) : base(ctx) { }

        public List<Recipients> GetAll()
        {
            return _ctx.Recipients.ToList();
        }

        
    }
}
