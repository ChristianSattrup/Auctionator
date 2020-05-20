using AuctionatorWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int BidPrice { get; set; }
        public int Bidder { get; set; }
        public int Auction { get; set; }
        public override string ToString()
        {
            AuctionatorContext Context = new AuctionatorContext();
            string bid = "Bid: " + BidPrice.ToString() + " , Is Highestbid: ";
            Context.Auctions.ToList().ForEach(a =>
            {
                if (a.Id == Auction)
                {
                    if (a.HighestBid == Id)
                    {
                        bid += "You are highest Bidder!";
                    } else
                    {
                        bid += "You are over bid!";
                    }
                }
            });
            return bid;
        }
    }
}