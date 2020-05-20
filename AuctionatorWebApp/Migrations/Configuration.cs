namespace AuctionatorWebApp.Migrations
{
    using AuctionatorWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionatorWebApp.Storage.AuctionatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionatorWebApp.Storage.AuctionatorContext context)
        {
            User user1 = new User { Name = "Test", Email = "Test", Password = "Test", ContactInfo = "Test" };
            User user2 = new User { Name = "Test1", Email = "Test1", Password = "Test1", ContactInfo = "Test1" };
            Auction a1 = new Auction { Amount = 1, Seller = 1, Deadline = DateTime.Today, StartPrice = 1, Item = "Test" };
            Auction a2 = new Auction { Amount = 2, Seller = 2, Deadline = DateTime.Today, StartPrice = 2, Item = "Test" };
            user1.Auctions.Add(1);
            user2.Auctions.Add(2);
            a1.HighestBid = 2;
            a2.HighestBid = 1;
            Bid b1 = new Bid { Auction = 1, Bidder = 2, BidPrice = 3 };
            Bid b2 = new Bid { Auction = 2, Bidder = 1, BidPrice = 4 };
            user2.Bids.Add(1);
            user1.Bids.Add(2);
            a1.Bids.Add(1);
            a2.Bids.Add(2);
            context.Users.AddOrUpdate(u => u.Email, user1);
            context.Users.AddOrUpdate(u => u.Email, user2);
            context.Auctions.AddOrUpdate(a => a.Id, a1);
            context.Auctions.AddOrUpdate(a => a.Id, a2);
            context.Bids.AddOrUpdate(b => b.Id, b1);
            context.Bids.AddOrUpdate(b => b.Id, b2);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
