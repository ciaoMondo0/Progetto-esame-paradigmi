using Microsoft.EntityFrameworkCore;
using Progetto_paradigmi.Progetto.Models.Context;
using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Models.Repositories
{
    public class RecipientsListRepository : GenericRepository<RecipientsList>
    {
        public RecipientsListRepository(MyDbContext ctx) : base(ctx) { }

        public List<RecipientsList> GetAll()
        {
            return _ctx.RecipientsList.ToList();
        }
        public RecipientsList FindByIds(params object[] id)
        {
           

         
            var idLista = Convert.ToInt64(id[0]);
            var idDestinatario = Convert.ToInt64(id[1]);

            return _ctx.RecipientsList
                .FirstOrDefault(ld => ld.DistributionListId == idLista && ld.RecipientId == idDestinatario);
        }

        public void Delete(RecipientsList entity)
        {
            
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
