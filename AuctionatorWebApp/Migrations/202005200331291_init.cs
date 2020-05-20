namespace AuctionatorWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Amount = c.Int(nullable: false),
                        StartPrice = c.Int(nullable: false),
                        HighestBid = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        Seller = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BidPrice = c.Int(nullable: false),
                        Bidder = c.Int(nullable: false),
                        Auction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Bids");
            DropTable("dbo.Auctions");
        }
    }
}
