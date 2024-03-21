using Progetto_paradigmi.Progetto.Application.DTO;
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
    public class DistributionListRepository : GenericRepository<DistributionList>
    {

        public DistributionListRepository(MyDbContext ctx) : base(ctx) { }

        public List<DistributionList> GetAll()
        {
            return _ctx.DistributionList.ToList();
        }

        public DistributionList GetById(int id)
        {
            return _ctx.DistributionList.Where(dl => dl.Id == id).FirstOrDefault();
        }

    }
}
