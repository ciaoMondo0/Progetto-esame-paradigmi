using Progetto_paradigmi.Progetto.Models.Context;

namespace Progetto_paradigmi.Progetto.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
            //_ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Ottieni(object id)
        {
            return _ctx.Set<T>()
                .Find(id);

        }

        public void Elimina(object id)
        {
            var entity = Ottieni(id);
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

    }
}
