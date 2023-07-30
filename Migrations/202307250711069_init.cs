namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        Classification = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        Number = c.Double(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "DeviceId", "dbo.Devices");
            DropIndex("dbo.PhoneNumbers", new[] { "DeviceId" });
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Devices");
            DropTable("dbo.Clients");
        }
    }
}
