
using AuctionatorDesktopApp.Views;
using AuctionatorWebApp.Models;
using AuctionatorWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuctionatorDesktopApp
{
    public partial class MainWindow : Window
    {
        public AuctionatorContext Context = new AuctionatorContext();
        public User User = null;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new LoginPage();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (User!=null)
            {
                LoggedOf();
            }
            Main.Content = new LoginPage();
        }
        private void CreateUserClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateUserPage();
        }
        private void AuctionsClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new AuctionsPage(User);
        }
        private void BidsClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new BidsPage(User);
        }
        //States
        public void LoggedIn(User user)
        {
            Login.Content = "Log Of";
            LoginStatus.Content = user.Name;
            User = user;
            Create.IsEnabled = false;
            Auctions.IsEnabled = true;
            Bids.IsEnabled = true;
        }
        public void LoggedOf()
        {
            LoginStatus.Content = "No login";
            Login.Content = "Login";
            User = null;
            Create.IsEnabled = true;
            Auctions.IsEnabled = false;
            Bids.IsEnabled = false;
        }
    }
}

