namespace Futbol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Futbolcus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FutbolcuAdÄ± = c.String(maxLength: 30, unicode: false),
                        FutbolcuNumarasÄ± = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Futbolcus");
        }
    }
}
