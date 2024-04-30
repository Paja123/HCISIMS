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
    /// Interaction logic for BestTourYearlyView.xaml
    /// </summary>
    public partial class BestTourYearlyView : Page
    {
        private User LoggedInGuide { get; set; }

        public ObservableCollection<TourBasicInfoDto> BasicTours { get; set; } = new ObservableCollection<TourBasicInfoDto>();
        public TourController TourController { get; set; } = new TourController();
        private int ColNum { get; set; } = 0;
        public ObservableCollection<string> TourYears { get; set; } = new ObservableCollection<string>();
        public TourGuestsDto BestTour { get; set; } = new TourGuestsDto();

        public BestTourYearlyView(User user)
        {
            LoggedInGuide = user;
            InitializeComponent();
            this.DataContext = this;
            List<TourBasicInfoDto> tours = GetFinishedTours(LoggedInGuide.Id);
            GetTourYears(tours);
        }

        private void GetTourYears(List<TourBasicInfoDto> tours)
        {
            foreach (TourBasicInfoDto tour in tours)
            {
                string year = tour.StartDateAndTime.Date.Year.ToString();
                if (!TourYears.Contains(year))
                {
                    TourYears.Add(year);
                }
            }
            TourYears.Add("All time");
        }

        private List<TourBasicInfoDto> GetFinishedTours(int guideId)
        {
            List<TourBasicInfoDto> tours = TourController.GetByStatus(guideId, TourStatus.Finished);

            foreach (TourBasicInfoDto tour in tours)
            {
                BasicTours.Add(tour);
            }

            return tours;
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

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string time = ComboBox1.Text;
            BestTour  = TourController.GetMostVisitedTour(LoggedInGuide.Id, time);

            WithVoucher.Content = BestTour.TotalWithVoucher + "%";
            WithOutVoucher.Content = BestTour.TotalWithoutVoucher + "%";
            young.Content = BestTour.TotalYouth;
            mid.Content = BestTour.TotalMiddleAged;
            old.Content = BestTour.TotalOld;


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
