using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoIdentity.Data
{
    public class AppDataUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        public virtual ICollection<House>? Houses { get; set; } = new List<House>();
    }
}
