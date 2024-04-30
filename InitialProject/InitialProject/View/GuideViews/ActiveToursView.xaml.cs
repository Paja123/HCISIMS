using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Enumeration;
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
   
    public partial class ActiveToursView : Page
    {
        private User LoggedInGuide { get; set; }
        public ObservableCollection<TourBasicInfoDto> BasicTours { get; set; } = new ObservableCollection<TourBasicInfoDto>();

        public TourController TourController { get; set; } = new TourController();
        public VoucherController VoucherController { get; set; } = new VoucherController();
        

        public ActiveToursView(User user)
        {
            LoggedInGuide = user;
            InitializeComponent();
            this.DataContext = this;
            GetUnfinishedTours(LoggedInGuide.Id);

            TextBlock1.Text = "Dodirnite turu i pritisnite Pregledaj turu za njen detaljniji prikaz";
            TextBlock2.Text = "Turu možete otkazati najkasnije 48 sati pre njenog starta!";
        }
        private void GetUnfinishedTours(int guideId)
        {
            List<TourBasicInfoDto> tours = TourController.GetByStatus(guideId, TourStatus.Waiting);
            foreach (TourBasicInfoDto tour in tours)
            {
                BasicTours.Add(tour);
            }
        }
        private void CancelTour(object sender, RoutedEventArgs e)
        {
            

            if (DataGridTours.SelectedItem != null)
            {
                TourBasicInfoDto tour = (TourBasicInfoDto)DataGridTours.SelectedItem;

                
                TimeSpan limit = new TimeSpan(0, 48, 0, 0);
                TimeSpan difference = tour.StartDateAndTime - DateTime.Now;
                if (difference > limit)
                {
                    CancelTourWindow cancelTourWindow = new CancelTourWindow(tour);
                    cancelTourWindow.DataReady += CancelTourWindow_DataReady;
                    cancelTourWindow.DataReadyClose += CancelTourWindow_DataReadyCancel;

                    ShowDimmedOverlay();
                    cancelTourWindow.Show();


                  //  TourController.Cancel(tour.id);
                  //  BasicTours.Remove(tour);
                }
            }
           

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

        private void ShowTodaysTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
        }

        private void ShowGuideHistory(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
        }

        private void PregledajTuru(object sender, RoutedEventArgs e)
        {
            if (DataGridTours.SelectedItem != null)
            {
                TourBasicInfoDto tour = (TourBasicInfoDto)DataGridTours.SelectedItem;
                Tour tourFromDb = TourController.GetById(tour.id);
                NavigationService?.Navigate(new TourDetailsView(LoggedInGuide, tourFromDb, true));

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
        private void ShowPopover(object sender, RoutedEventArgs e)
        {
            if (MyPopover1.IsOpen)
            {
                HideDimmedOverlay();
                MyPopover1.IsOpen = false; // Hide the popover if it's already open
            }
            else
            {
                ShowDimmedOverlay();
                MyPopover1.IsOpen = true; // Show the popover
            }
        }
        private void ShowPopover2(object sender, RoutedEventArgs e)
        {
            if (MyPopover2.IsOpen)
            {
                HideDimmedOverlay();
                MyPopover2.IsOpen = false; // Hide the popover if it's already open
            }
            else
            {
                ShowDimmedOverlay();
                MyPopover2.IsOpen = true; // Show the popover
            }
        }
        private void CancelTourWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
            TourController.Cancel(e.baisicTour.id);
            BasicTours.Remove(e.baisicTour);
        }
        private void CancelTourWindow_DataReadyCancel(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
           
        }
    }
}
