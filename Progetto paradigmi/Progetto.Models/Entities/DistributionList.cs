using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_paradigmi.Progetto.Models.Entities
{
    [Table("DistributionList")]
    public class DistributionList
    {

        

        public DistributionList()
        {
        }

        public int Id { get; set; } 

        public string Name { get; set; }
        public Utenti Owner { get; set; }

        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }


        public virtual ICollection<Recipients> RecipientsEmails { get; set; }
        public ICollection<RecipientsList> RecipientsLists { get; set; }



    }
}
