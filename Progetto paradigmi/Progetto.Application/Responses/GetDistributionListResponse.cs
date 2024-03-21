using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Application.Responses
{
    public class GetDistributionListResponse
    {
        public List<DistributionList> distributionList { get; set; } = new List<DistributionList>();
        public int NumeroPagine { get; set; }
    }
}
