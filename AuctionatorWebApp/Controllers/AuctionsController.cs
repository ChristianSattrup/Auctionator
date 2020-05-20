using AuctionatorWebApp.Models;
using AuctionatorWebApp.Storage;
using AuctionatorWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionatorWebApp.Controllers
{
    public class AuctionsController : Controller
    {
        public ActionResult ViewAllAuctions()
        {
            List<Auction> auctions = new List<Auction>();
            AuctionatorContext _context = new AuctionatorContext();
            _context.Auctions.ToList().ForEach((a) => {
                auctions.Add(a);
            });
            ViewAuctionsViewModel viewAuctionsViewModel = new ViewAuctionsViewModel
            {
                auctions = auctions
            };
            return View(viewAuctionsViewModel);
        }
        public ActionResult ViewMyAuctions()
        {
            AuctionatorContext _context = new AuctionatorContext();
            List<Auction> auctions = new List<Auction>();
            User user = Session["user"] as User;
            if (user != null)
            {
                _context.Auctions.ToList().ForEach((a) => {
                    if (a.Seller == user.Id)
                    {
                        auctions.Add(a);
                    }
                });
                ViewAuctionsViewModel viewAuctionsViewModel = new ViewAuctionsViewModel
                {
                    auctions = auctions
                };
                return View(viewAuctionsViewModel);
            }
            else
            {
                return Redirect("/login/login");
            }
        }
        public ActionResult Create()
        {
            return View(new CreateAuctionViewModel());
        }
        public ActionResult CreateAuction(CreateAuctionViewModel createAuctionViewModel)
        {
            AuctionatorContext _context = new AuctionatorContext();
            User user = Session["user"] as User;
            Auction auction = new Auction();
            auction.Seller = user.Id;
            auction.Item = createAuctionViewModel.Item;
            auction.Amount = createAuctionViewModel.Amount;
            auction.StartPrice = createAuctionViewModel.StartPrice;
            auction.Deadline = createAuctionViewModel.Deadline;
            Auction newAuc = _context.Auctions.Add(auction);
            user.Auctions.Add(newAuc.Id);
            _context.SaveChanges();
            Session["user"] = user;
            return Redirect("/auctions/ViewMyAuctions");
        }
    }
}