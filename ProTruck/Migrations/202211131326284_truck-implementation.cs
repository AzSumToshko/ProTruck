namespace ProTruck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truckimplementation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        brand = c.String(),
                        model = c.String(),
                        description = c.String(),
                        fileName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trucks");
        }
    }
}
