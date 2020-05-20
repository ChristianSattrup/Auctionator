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

namespace AuctionatorDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for BidsPage.xaml
    /// </summary>
    public partial class BidsPage : Page
    {
        private AuctionatorContext Context = new AuctionatorContext();
        public BidsPage(User user)
        {
            InitializeComponent();

            lbBids.Items.Clear();
            foreach (Bid bid in Context.Bids.ToList())
            {
                if (bid.Bidder == user.Id)
                {
                    lbBids.Items.Add(bid);
                }
            }
        }
    }
}
