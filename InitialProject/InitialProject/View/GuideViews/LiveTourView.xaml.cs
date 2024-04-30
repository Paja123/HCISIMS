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
using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Enumeration;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for LiveTourView.xaml
    /// </summary>
    public partial class LiveTourView : Page
    {
        public User LoggedInGuide { get; set; }
        public List<TourKeyPoint> keyPoints { get; set; } = new List<TourKeyPoint>();
        public TourKeyPointController TourKeyPointController { get; set; } = new TourKeyPointController();
        public TourReservationController TourReservationController { get; set; } = new TourReservationController();
        public ObservableCollection<TourReservation> Reservations { get; set; } = new ObservableCollection<TourReservation>();

        public TourController tourController { get; set; } = new TourController();
        private TourKeyPoint _lastCheckedKeyPoint { get; set; }
        public Tour Tour { get; set; }
        public LiveTourView(User user,Tour tour)
        {
            LoggedInGuide = user;
               Tour = tour;
            TourKeyPointController.StartTour(Tour.Id);
            Tour.TourKeyPoints.First().Reached = true;
            keyPoints.AddRange(tour.TourKeyPoints);
            
            this.DataContext = this;
            
            List<TourReservation> reservations = TourReservationController.GetByTour(tour.Id);

            foreach (TourReservation reservation in reservations)
            {
                Reservations.Add(reservation);
            }
            InitializeComponent();
            Label.Content = tour.Name;
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

        private void CheckKeyPoint(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            TourKeyPoint keyPoint = (TourKeyPoint)checkBox.DataContext;

            TourKeyPointController.Reach(keyPoint.Id, keyPoint.Type);

            _lastCheckedKeyPoint = keyPoint;

            if (keyPoint.Type == TourKeyPointType.End)
            {
                EndTour();
            }
        }
        private void EndTour()
        {
            tourController.SetStatus(Tour.Id, TourStatus.Finished);
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));

        }


        private void EndTourButton(object sender, RoutedEventArgs e)
        {
            tourController.SetStatus(Tour.Id, TourStatus.Finished);
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
            
        }


        private void ShowGuestChecking(object sender, RoutedEventArgs e)
        {
            TouristCheckingView touristCheckingView = new TouristCheckingView(Reservations, _lastCheckedKeyPoint);
            touristCheckingView.DataReady += touristCheckingView_DataReady;
            touristCheckingView.Show();
            ShowDimmedOverlay();
        }

        private void touristCheckingView_DataReady(object sender, DataEventArgs e)
        {
                HideDimmedOverlay();
        }
        private void ShowTodaysTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
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

    }
}
