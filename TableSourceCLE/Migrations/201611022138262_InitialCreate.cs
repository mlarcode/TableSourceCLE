namespace TableSourceCLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        donationID = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false),
                        pickUpDate = c.DateTime(nullable: false),
                        pickupTime = c.String(nullable: false),
                        weight = c.Double(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.donationID);
            
            CreateTable(
                "dbo.DonorCategories",
                c => new
                    {
                        donorCategoryID = c.Int(nullable: false, identity: true),
                        donorCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.donorCategoryID);
            
            CreateTable(
                "dbo.DonorOrganizations",
                c => new
                    {
                        donorID = c.Int(nullable: false, identity: true),
                        donorName = c.String(),
                        donorAddress = c.String(),
                        donorCity = c.String(),
                        donorState = c.String(),
                        donorZip = c.Int(nullable: false),
                        donorPhone = c.String(),
                        donorEmail = c.String(),
                        donorTaxID = c.String(),
                        donorCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.donorID)
                .ForeignKey("dbo.DonorCategories", t => t.donorCategoryID, cascadeDelete: true)
                .Index(t => t.donorCategoryID);
            
            CreateTable(
                "dbo.RecipientCategories",
                c => new
                    {
                        recipientCategoryID = c.Int(nullable: false, identity: true),
                        recipientCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.recipientCategoryID);
            
            CreateTable(
                "dbo.RecipientOrganizations",
                c => new
                    {
                        recipientID = c.Int(nullable: false, identity: true),
                        recipientName = c.String(),
                        recipientAddress = c.String(),
                        recipientCity = c.String(),
                        recipientState = c.String(),
                        recipientZip = c.Int(nullable: false),
                        recipientPhone = c.String(),
                        recipientEmail = c.String(),
                        recipientTaxID = c.String(),
                        recipientCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.recipientID)
                .ForeignKey("dbo.RecipientCategories", t => t.recipientCategoryID, cascadeDelete: true)
                .Index(t => t.recipientCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipientOrganizations", "recipientCategoryID", "dbo.RecipientCategories");
            DropForeignKey("dbo.DonorOrganizations", "donorCategoryID", "dbo.DonorCategories");
            DropIndex("dbo.RecipientOrganizations", new[] { "recipientCategoryID" });
            DropIndex("dbo.DonorOrganizations", new[] { "donorCategoryID" });
            DropTable("dbo.RecipientOrganizations");
            DropTable("dbo.RecipientCategories");
            DropTable("dbo.DonorOrganizations");
            DropTable("dbo.DonorCategories");
            DropTable("dbo.Donations");
        }
    }
}
