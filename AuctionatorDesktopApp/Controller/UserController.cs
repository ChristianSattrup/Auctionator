using AuctionatorDesktopApp.Views;
using AuctionatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AuctionatorDesktopApp.Controller
{
    public class UserController : Controller
    {
        public static void Create(CreateUserPage createUserPage)
        {
            User user = new User
            {
                Name = createUserPage.UserName.Text,
                Email = createUserPage.UserEmail.Text,
                Password = createUserPage.UserPassword.Text,
                ContactInfo = createUserPage.UserContactInfo.Text
            };
            UI.Context.Users.Add(user);
            UI.Context.SaveChanges();
            UI.User = user;
            UI.LoggedIn(user);
            UI.Main.Content = new AuctionsPage(user);
        }
        public static void Login(LoginPage loginPage)
        {
            User user = null;
            UI.Context.Users.ToList().ForEach(u =>
            {
                if (u.Email == loginPage.LoginEmail.Text && u.Password == loginPage.LoginPassword.Text)
                {
                    user = u;
                }
            }
            );
            if (user == null)
            {
                MessageBox.Show("Email or password is wrong, or user didnt exist");
            }
            else
            {
                UI.LoggedIn(user);
                UI.Main.Content = new AuctionsPage(user);
            }
        }
        public static void LogOf()
        {
            UI.LoggedOf();
        }
        public static void CreateBid(Auction auction, int bidPrice, AuctionsPage auctionsPage)
        {
            Bid bid = UI.Context.Bids.Add(new Bid
            {
                Auction = auction.Id,
                BidPrice = bidPrice,
                Bidder = UI.User.Id
            });

            UI.User.Bids.Add(bid.Id);
            auction.Bids.Add(bid.Id);
            int hBid = 0;
            foreach (Bid b in UI.Context.Bids)
            {
                if (b.Auction==auction.Id)
                {
                    if (hBid<b.BidPrice)
                    {
                        auction.HighestBid = b.Id;
                    }
                }
            }
            UI.Context.SaveChanges();
            auctionsPage.UpdateData();
        }
    }
}
