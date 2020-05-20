using AuctionatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.Storage
{
    public class AuctionatorContext : DbContext
    {
        public AuctionatorContext() : base("name=AuctionatorConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}