using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Progetto_paradigmi.Progetto.Models.Entities
{
    [Table("Utenti")]

    public class Utenti
    {
       

        public String Email {  get; set; }   
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get;  set; }
    }
}
