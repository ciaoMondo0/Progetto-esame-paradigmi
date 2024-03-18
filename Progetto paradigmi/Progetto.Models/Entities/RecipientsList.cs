namespace Progetto_paradigmi.Progetto.Models.Entities
{
    public class RecipientsList
    {
       public int RecipientId { get; set; }
        public int DistributionListId { get; set; }

        public DistributionList DistributionList { get; set; }
        public Recipients Recipients { get; set; }
    }
}
