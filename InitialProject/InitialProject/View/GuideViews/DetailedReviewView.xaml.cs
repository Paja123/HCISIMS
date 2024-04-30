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
using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for DetailedReviewView.xaml
    /// </summary>
    public partial class DetailedReviewView : Page
    {
        public BasicTourReviewDto BasicReview { get; set; }
        public TourController TourController { get; set; } = new TourController();
        public TourReviewController TourReviewController { get; set; } = new TourReviewController();
        public string KeyPointNames { get; set; }
        public User LoggedInGuide { get; set; }
        public DetailedReviewView(User user,BasicTourReviewDto review)
        {
            LoggedInGuide = user;
            BasicReview = review;
            BasicReview.Review.Comment = TourReviewController.GetCommentById(BasicReview.Review.Id);
            KeyPointNames = GetKeyPointNames(review.Review.Reservation.Tour.Id);
            this.DataContext = this;
            InitializeComponent();
        }

        private string GetKeyPointNames(int id)
        {
            return TourController.GetKeyPointNames(id);
        }

        private void NavigateBack(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourReviewsView(LoggedInGuide,BasicReview.Review.Reservation.Tour.Id));
        }

        private void ReportGuest(object sender, RoutedEventArgs e)
        {
            BlurPage();
            string text = "Sigurno želite da prijavite korisnika: " + Environment.NewLine + BasicReview.TouristName;
            MessageBoxResult result = MessageBox.Show(text, caption:String.Empty, MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                TourReviewController.Invalidate(BasicReview.Review.Id);

                string confirmation = "Korisnik : " + Environment.NewLine + BasicReview.TouristName + Environment.NewLine + "je uspešno prijavljen";
                MessageBoxResult confirmationMessageBox = MessageBox.Show(confirmation, caption: String.Empty, MessageBoxButton.OK);

            }
            UnBlurPage();

        }

        private void ShowComment(object sender, RoutedEventArgs e)
        {
            BlurPage();
            CommentPopUp commentPopUp = new CommentPopUp(BasicReview.Review.Comment);
            commentPopUp.Show();
            UnBlurPage();

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
            if (NavigationMenu.Visibility == Visibility.Collapsed){
                ShowNavigationMenu();
                ShowDimmedOverlay();
            }else
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


        private void ShowTodayTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
        }

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void ShowGuideHistory(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
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
