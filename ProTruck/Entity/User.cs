using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProTruck.Entity
{
    /*
     * This is the entity that is going to be used for the authentication(Login/Register) and for the logged user
     */
    [Table("Users")]
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
