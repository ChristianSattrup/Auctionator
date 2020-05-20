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
    public class LoginController : Controller
    {
        private AuctionatorContext _context = new AuctionatorContext();
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        public ActionResult Autherize(string useremailData, string passwordData)
        {
            User user = null;
            _context.Users.ToList().ForEach(u =>
            {
                if (u.Email == useremailData && u.Password == passwordData)
                {
                    user = u;
                }
            }
            );
            if (user == null)
            {
                return Redirect("/login/login");
            }
            else
            {
                Session["user"] = user;
                return Redirect("/auctions/ViewAllAuctions");
            }

        }
        public ActionResult Create(LoginViewModel loginViewModel)
        {
            User user = new User();
            user.Name = loginViewModel.Name;
            user.Email = loginViewModel.Email;
            user.Password = loginViewModel.Password;
            user.ContactInfo = loginViewModel.ContactInfo;
            _context.Users.Add(user);
            _context.SaveChanges();
            Session["user"] = user;
            return Redirect("/auctions/create");
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}