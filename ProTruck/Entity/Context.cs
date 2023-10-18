using System.Data.Entity;

namespace ProTruck.Entity
{
    /*
     * Context class is the class which links the database to the application
     * by inheriting the DbContext class we now can use the methods that the class has.
     */
    public class Context : DbContext
    {
        /*
         * The properyies Users and Trucks store the information about the entities that is existing in the database
         */
        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        /*
         * The constructor inherits from the base class and there is the connectionstring that conects the database to the web application
         */
        public Context() : base("Server=localhost\\SQLEXPRESS;Database=ProTruck;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            Trucks = this.Set<Truck>();
        }
    }
}
