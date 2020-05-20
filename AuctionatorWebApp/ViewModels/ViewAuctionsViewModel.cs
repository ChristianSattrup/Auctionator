using AuctionatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.ViewModels
{
    public class ViewAuctionsViewModel
    {
        public List<Auction> auctions { get; set; }
    }
}