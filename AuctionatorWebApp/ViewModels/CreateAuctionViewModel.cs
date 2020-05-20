using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionatorWebApp.ViewModels
{
    public class CreateAuctionViewModel
    {
        public string Item { get; set; }
        public int Amount { get; set; }
        public int StartPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
    }
}