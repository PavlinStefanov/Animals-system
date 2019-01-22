namespace AnimalsSupportSystem.Infrastucture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptionCenters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AnimalRegisters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Age = c.Int(),
                        Type = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 7),
                        Color = c.String(nullable: false, maxLength: 30),
                        IsCleansed = c.Boolean(nullable: false),
                        CleanseCenterID = c.Int(),
                        AdoptionCenterID = c.Int(),
                        DeseaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AdoptionCenters", t => t.AdoptionCenterID)
                .ForeignKey("dbo.CleanseCenters", t => t.CleanseCenterID)
                .ForeignKey("dbo.Deseases", t => t.DeseaseID, cascadeDelete: true)
                .Index(t => t.CleanseCenterID)
                .Index(t => t.AdoptionCenterID)
                .Index(t => t.DeseaseID);
            
            CreateTable(
                "dbo.CleanseCenters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Deseases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recievers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Age = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsClosed = c.Boolean(nullable: false),
                        RecieverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recievers", t => t.RecieverID, cascadeDelete: true)
                .Index(t => t.RecieverID);
            
            CreateTable(
                "dbo.RequestDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        AnimalType = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false, maxLength: 7),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Requests", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestDetails", "ID", "dbo.Requests");
            DropForeignKey("dbo.Requests", "RecieverID", "dbo.Recievers");
            DropForeignKey("dbo.AnimalRegisters", "DeseaseID", "dbo.Deseases");
            DropForeignKey("dbo.AnimalRegisters", "CleanseCenterID", "dbo.CleanseCenters");
            DropForeignKey("dbo.AnimalRegisters", "AdoptionCenterID", "dbo.AdoptionCenters");
            DropIndex("dbo.RequestDetails", new[] { "ID" });
            DropIndex("dbo.Requests", new[] { "RecieverID" });
            DropIndex("dbo.AnimalRegisters", new[] { "DeseaseID" });
            DropIndex("dbo.AnimalRegisters", new[] { "AdoptionCenterID" });
            DropIndex("dbo.AnimalRegisters", new[] { "CleanseCenterID" });
            DropTable("dbo.RequestDetails");
            DropTable("dbo.Requests");
            DropTable("dbo.Recievers");
            DropTable("dbo.Deseases");
            DropTable("dbo.CleanseCenters");
            DropTable("dbo.AnimalRegisters");
            DropTable("dbo.AdoptionCenters");
        }
    }
}
