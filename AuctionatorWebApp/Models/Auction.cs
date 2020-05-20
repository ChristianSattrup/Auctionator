using AuctionatorWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.Models
{
    public class Auction
    {
        public Auction()
        {
            this.Bids = new List<int>();
            HighestBid = -1;
        }
        public int Id { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
        public int StartPrice { get; set; }
        public int HighestBid { get; set; }
        public DateTime Deadline { get; set; }
        public int Seller { get; set; }
        public List<int> Bids { get; set; }
        public override string ToString()
        {
            AuctionatorContext Context = new AuctionatorContext();
            string auction = "Item: " + Item + " ,Amount: " + Amount.ToString() + " ,StartPrice: " + StartPrice.ToString();
            bool found = false;
            int price = 0;
            Context.Bids.ToList().ForEach(b =>
            {
                if (b.Id == HighestBid)
                {
                    found = true;
                    price = b.BidPrice;
                }
            });
            if (found)
            {
            auction += " ,Highest Bid: " + price.ToString() + " by: ";
            Context.Users.ToList().ForEach(u =>
            {
                if (u.Id == HighestBid)
                {
                    auction += u.Name;
                }
            });
            }
            else
            {
                auction += " ,Highest Bid: None";
            }
            Context.Users.ToList().ForEach(u =>
            {
                if (u.Id==Seller)
                {
                    auction += " ,Sold by: " + u.Name;
                }
            });
            return auction;
        }
    }
}