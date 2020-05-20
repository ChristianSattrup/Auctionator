using AuctionatorDesktopApp.Controller;
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
using System.Windows.Threading;

namespace AuctionatorDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for AuctionsPage.xaml
    /// </summary>
    public partial class AuctionsPage : Page
    {
        private AuctionatorContext Context = new AuctionatorContext();
        private User user;
        private int UIUpdateCountdown = 0;
        public AuctionsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            UpdateData();
            StatAutoUpdate();
        }
        public void UpdateData()
        {
            Auction selectedAuction = null;
            if (lbAuctions.SelectedItem!=null)
            {
                selectedAuction = (Auction)lbAuctions.SelectedItem;
            }
            lbAuctions.Items.Clear();
            foreach (Auction auction in Context.Auctions.ToList())
            {
                if (auction.Seller == user.Id)
                {
                    lbAuctions.Items.Add(auction);
                }
            }
            if (selectedAuction!=null)
            {
                lbAuctions.SelectedItem = selectedAuction;
            }
        }
        private void MakeBidClick(object sender, RoutedEventArgs e)
        {
            if (lbAuctions.SelectedItem != null && Int32.TryParse(tbBid.Text,out int j))
            {
                UserController.CreateBid((Auction)lbAuctions.SelectedItem, j, this);
                Update();
            }
        }
        private void Update()
        {
            UIUpdateCountdown = 0;
            UpdateData();
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string updateTxt = "";
            pbUpdate.Value = UIUpdateCountdown;

            if (UIUpdateCountdown<20)
            {
                updateTxt = "Click to update(AutoUpdate in 5 seconds)";
            }
            if (20 <= UIUpdateCountdown && UIUpdateCountdown < 40)
            {
                updateTxt = "Click to update(AutoUpdate in 4 seconds)";
            }
            if (40 <= UIUpdateCountdown && UIUpdateCountdown < 60)
            {
                updateTxt = "Click to update(AutoUpdate in 3 seconds)";
            }
            if (60 <= UIUpdateCountdown && UIUpdateCountdown < 80)
            {
                updateTxt = "Click to update(AutoUpdate in 2 seconds)";
            }
            if (80 <= UIUpdateCountdown && UIUpdateCountdown < 100)
            {
                updateTxt = "Click to update(AutoUpdate in 1 seconds)";
            }
            if (UIUpdateCountdown == 100)
            {
                updateTxt = "Click to update(AutoUpdate in 0 seconds)";
                UpdateData();
            }
            UIUpdateCountdown += 1;
            if (UIUpdateCountdown == 101)
            {
                updateTxt = "Click to update(AutoUpdate in 0 seconds)";
                UIUpdateCountdown = 0;
            }
            lbProgress.Content = updateTxt;
        }
        private void StatAutoUpdate()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(days:00, hours:00, minutes:0, seconds:00, milliseconds:60);
            dispatcherTimer.Start();
        }
    }
}
