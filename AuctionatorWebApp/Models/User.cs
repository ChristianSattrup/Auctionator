using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Auctions = new List<int>();
            this.Bids = new List<int>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactInfo { get; set; }
        public List<int> Bids { get; set; }
        public List<int> Auctions { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}