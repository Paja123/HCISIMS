using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using InitialProject.Service;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for TourDetailsView.xaml
    /// </summary>
    public partial class TourDetailsView : Page
    {
        public User LoggedInGuide { get; set; }
        public Tour Tour { get; set; }
        public List<string> KeyPointNames { get; set; } = new List<string>();
        public TourReservationController TourReservationController { get; set; } = new TourReservationController();
        public TourController TourController { get; set; } = new TourController();
        public TourDetailsView(User user, Tour tour)
        {
            LoggedInGuide = user;
            Tour = tour;

            this.DataContext = this;
            InitializeComponent();
            KeyPointNames.Add("Ključne tačke");
            foreach (TourKeyPoint keyPoint in Tour.TourKeyPoints)
            {
                KeyPointNames.Add(keyPoint.Name);
            }
            
            Name.Text = Tour.Name;
            Language.Text = Tour.Language;
            Country.Text = Tour.Location.Country;
            City.Text = Tour.Location.City;
            Date.Text = Tour.StartDateAndTime.Date.ToShortDateString();
            StartTime.Text = Tour.StartDateAndTime.TimeOfDay.ToString();
            Duration.Text = Tour.Duration.Hours.ToString().TrimStart('0');
            GuestLimit.Text = Tour.GuestLimit.ToString();
            GuestNumber.Text = GetGuestNumber();
            ComboBox.SelectedItem = KeyPointNames.First();
            ComboBox.IsReadOnly = true;
            KeyPointNames.Remove("Ključne tačke");
            ComboBox.IsEditable = false;
            
        }

        public TourDetailsView(User user, Tour tour, bool HideStartTourButton) : this(user, tour)
        {
            StartTourButton.Visibility = Visibility.Collapsed;
        }

        private string GetGuestNumber()
        {
                return TourReservationController.GetNumberOfGuests(Tour.Id).ToString();
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TourDescriptionWindow tourDescriptionWindow = new TourDescriptionWindow(Tour.Description);
            tourDescriptionWindow.DataReady += tourDescriptionWindow_DataReady;
            tourDescriptionWindow.Show();
            ShowDimmedOverlay();
        }

        private void StartTour(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LiveTourView(LoggedInGuide, Tour));
        }
        private void tourDescriptionWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();

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

        private void ViewTodayTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
        }

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void TourHistoryView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
        }
    }

}
