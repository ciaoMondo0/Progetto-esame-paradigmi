using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Utenti Owner { get; set; }

        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Recipients> RecipientsEmails { get; set; }

        [JsonIgnore]
        public ICollection<RecipientsList> RecipientsLists { get; set; }



    }
}
