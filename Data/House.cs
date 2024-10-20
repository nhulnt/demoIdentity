using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.Data
{
    public class House
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string address { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual AppDataUser? Owner { get; set; }
    }
}
