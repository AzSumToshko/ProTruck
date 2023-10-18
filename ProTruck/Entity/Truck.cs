using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProTruck.Entity
{
    /*
     * This is the main entity which is going to be displayed on the catalogue
     */
    [Table("Trucks")]
    public class Truck
    {
        [Key]
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }
    }
}
