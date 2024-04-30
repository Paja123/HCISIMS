using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class TourReviewsView : Page
    {
        public TourReviewController TourReviewController = new TourReviewController();
        public TourController TourController { get; set; } = new TourController();
        public TourReservationController TourReservationController = new TourReservationController();
        public User LoggedInGuide { get; set; }
        private int tourId { get; set; }
        public ObservableCollection<BasicTourReviewDto> basicTourReviews { get; set; } = new ObservableCollection<BasicTourReviewDto>();
        private List<TourReview> reviews = new List<TourReview>();
        public TourReviewsView(User user, int tourId)
        {

            this.tourId = tourId;
            this.LoggedInGuide = user;

            GetReviews(tourId);
            this.DataContext = this;
            InitializeComponent();

           

        }
        public void GetReviews(int id)
        {
            reviews = TourReviewController.GetManyByTour(id);

            foreach (TourReview review in reviews)
            {
                TourReservation reservation = TourReservationController.GetById(review.Reservation.Id);
                String keyPointName = TourReservationController.GetArrivalKeyPointName(reservation.Id);
                basicTourReviews.Add(new BasicTourReviewDto(reservation.BookingGuest.Username, review.Valid, review, keyPointName));
            }
        }

        // private void InvalidateReview(object sender, RoutedEventArgs e)
        // {
        //
        //     CheckBox checkBox = (CheckBox)sender;
        //     BasicTourReviewDto basicReview = (BasicTourReviewDto)checkBox.DataContext;
        //
        //     TourReviewController.Invalidate(basicReview.Review.Id);
        //
        // }

        private void ShowDetailedReview(object sender, RoutedEventArgs e)
        {
            if (dataGridBasicReviews.SelectedItem != null)
            {
                BasicTourReviewDto review = (BasicTourReviewDto)dataGridBasicReviews.SelectedItem;

                NavigationService?.Navigate(new DetailedReviewView(LoggedInGuide, review));

            }
           
        }

        private void NavigateBack(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
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

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void ShowHistoryView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
        }

        private void ShowTodayTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));

        }

        private void ShowFirstCreateTourView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide));
        }

        private void ShowSuperVodic(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SuperGuideView(LoggedInGuide));

        }

        private void ShowTourRequests(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourRequestsView(LoggedInGuide));
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LoginView());

        }

        private void QuitJob(object sender, RoutedEventArgs e)
        {
            TourController.Quit(LoggedInGuide);
            NavigationService?.Navigate(new LoginView());
        }
    }
}
