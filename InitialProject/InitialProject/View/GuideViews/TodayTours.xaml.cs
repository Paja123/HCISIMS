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
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for TodayTours.xaml
    /// </summary>
    public partial class TodayTours : Page
    {
        public User LoggedInGuide { get; set; }
        public ObservableCollection<TourBasicInfoDto> BasicTours { get; set; }

        public TourController TourController { get; set; } = new TourController();
        public VoucherController VoucherController { get; set; } = new VoucherController();
        public TodayTours(User user)
        {
            LoggedInGuide = user;
            this.DataContext = this;
            BasicTours = new ObservableCollection<TourBasicInfoDto>();
            
            if (LoggedInGuide != null)
            {
                BasicTours = GetTodaysTours(LoggedInGuide.Id);
            }
            else
            {
                LoggedInGuide = user;
            }
            InitializeComponent();
            TextBlock.Text = "Dodirnite turu i pritisnite Pregledaj turu za njen detaljniji prikaz";
        }

        private ObservableCollection<TourBasicInfoDto> GetTodaysTours(int id)
        {
            List<TourBasicInfoDto> tours = TourController.GetTodays().Where(t => t.GuideId == LoggedInGuide.Id).ToList();

          
            return new ObservableCollection<TourBasicInfoDto>(tours);
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
            NavigationService?.GoBack();
        }

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void ShowGuideHistory(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGridTours.SelectedItem != null)
            {
                TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;
                Tour tour = TourController.GetById(selectedTour.id);

                NavigationService?.Navigate(new TourDetailsView(LoggedInGuide, tour));

            }
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
