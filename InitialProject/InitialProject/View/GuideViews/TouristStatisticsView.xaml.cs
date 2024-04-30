using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for TouristStatisticsView.xaml
    /// </summary>
    public partial class TouristStatisticsView : Page
    {

        public TourReviewController TourReviewController = new TourReviewController();
        public TourController TourController { get; set; }= new TourController();
        public TourStatisticsDto Statistics { get; set; } = new TourStatisticsDto();
        public TourGuestsDto TotalStatistics { get; set; } = new TourGuestsDto();
        public User LoggedInUser { get; set; }
        public TouristStatisticsView(User user,int id, string tourName)
        {
            List<TourReview> reviews = TourReviewController.GetManyByTour(id);
            Statistics = new TourStatisticsDto();
            SetStatistics(reviews);
            Statistics.TourName = tourName;
            LoggedInUser = user;
            this.DataContext = this;
            InitializeComponent();
            TextBlock.Text =
                "Starosne grupe: \nMlađi (0 - 18 godina)\nSredovečni (19 - 50 godina) \nStariji (> 50 godina)";
        }
        private void SetVoucherUsagePercentage(List<TourReservation> reservations)
        {
            int voucherCount = 0;
            int total = reservations.Count;
            if (total > 0)
            {
                foreach (TourReservation reservation in reservations)
                {
                    if (reservation.Voucher != null) voucherCount++;
                }
                Statistics.WithVouchers = (int)((double)voucherCount / (double)total * 100.0);
                Statistics.WithoutVouchers = 100 - Statistics.WithVouchers;

                Statistics.WithVouchersString = Statistics.WithVouchers + "%";
                Statistics.WithoutVouchersString = Statistics.WithoutVouchers + "%";

            }
        }

        private void SetStatistics(List<TourReview> reviews)
        {


            List<TourReservation> reservations = reviews.Select(t => t.Reservation).ToList();

            List<User?> tourists = reviews.Select(r => r.Reservation.BookingGuest).ToList();

            foreach (var user in tourists)
            {
                if (user != null && user.Age < 18)
                {
                    Statistics.YouthCount++;
                }
                else
                {
                    if (user.Age < 50)
                    {
                        Statistics.MiddleAgedCount++;
                    }
                    else
                    {
                        Statistics.OldPeopleCount++;
                    }
                }
            }
            SetVoucherUsagePercentage(reservations);


        }
        private void BlurPage()
        {
            this.Opacity = 0.7;

            this.Effect = new DropShadowEffect();
        }

        private void UnBlurPage()
        {
            this.Opacity = 1;
            this.Effect = null;

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationMenu.Visibility == Visibility.Collapsed)
            {
                ShowNavigationMenu();
                ShowDimmedOverlay();
            }
            else
            {
                HideNavigationMenu();
                HideDimmedOverlay();
            }

        }
        private void ShowDimmedOverlay()
        {
            DimmedOverlay.Visibility = Visibility.Visible;
        }

        private void HideDimmedOverlay()
        {
            DimmedOverlay.Visibility = Visibility.Collapsed;
        }

        private void ShowNavigationMenu()
        {
            NavigationMenu.Visibility = Visibility.Visible;
        }

        private void HideNavigationMenu()
        {
            NavigationMenu.Visibility = Visibility.Collapsed;
        }

        private void DimmedOverlay_Click(object sender, RoutedEventArgs e)
        {
            HideNavigationMenu();
            HideDimmedOverlay();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInUser));

        }

        private void ShowTodaysTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInUser));
        }

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInUser));
        }

        private void ShowGuideHistory(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInUser));
        }

        private void ShowFirstCreateTourView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTourFirstView(LoggedInUser));
        }

        private void ShowSuperVodic(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SuperGuideView(LoggedInUser));

        }

        private void ShowTourRequests(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourRequestsView(LoggedInUser));
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LoginView());

        }

        private void QuitJob(object sender, RoutedEventArgs e)
        {
            TourController.Quit(LoggedInUser);
            NavigationService?.Navigate(new LoginView());
        }
        private void ShowPopover(object sender, RoutedEventArgs e)
        {
            if (MyPopover.IsOpen)
            {
                HideDimmedOverlay();
                MyPopover.IsOpen = false; // Hide the popover if it's already open
            }
            else
            {
                ShowDimmedOverlay();
                MyPopover.IsOpen = true; // Show the popover
            }
        }
    }
}
