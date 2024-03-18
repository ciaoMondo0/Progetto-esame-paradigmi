using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_paradigmi.Progetto.Models.Entities
{

    [Table("Recipients")]
    public class Recipients
    {

        public int Id { get; set; } 
        public string Email { get; set; }
        public virtual ICollection<DistributionList> DistributionList { get; set; }

        public ICollection<RecipientsList> RecipientsLists { get; set; }
    }
}
