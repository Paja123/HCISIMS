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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Colors = System.Windows.Media.Colors;


namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for TourHistoryView.xaml
    /// </summary>
    public partial class TourHistoryView : Page
    {
        private User LoggedInGuide { get; set; }

        public ObservableCollection<TourBasicInfoDto> BasicTours { get; set; } = new ObservableCollection<TourBasicInfoDto>();
        public TourController TourController { get; set; } = new TourController();
        private int ColNum { get; set; } = 0;
        public ObservableCollection<string> TourYears { get; set; } = new ObservableCollection<string>();
        public TourHistoryView(User user)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTours.SelectedItem != null)
            {

                TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;

                NavigationService?.Navigate(new TourReviewsView(LoggedInGuide, selectedTour.id));
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGridTours.SelectedItem != null)
            {
                TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;

                NavigationService?.Navigate(new TouristStatisticsView(LoggedInGuide, selectedTour.id, selectedTour.Name));
            }
        }

        private void BestTourTimePickerWindow_DataReady(object sender, DataEventArgs e)
        {
            Tour tour = e.Tour;
            NavigationService?.Navigate(new TourDetailsView(LoggedInGuide, tour, true));
            HideDimmedOverlay();
        }
        private void BestTourTimePickerWindowClose_DataReady(object sender, DataEventArgs e)
        {
           
            HideDimmedOverlay();
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
        /*private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
{
PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
e.Column.Header = propertyDescriptor.DisplayName;
if (propertyDescriptor.DisplayName == "id" || propertyDescriptor.DisplayName == "GuideId")
{
e.Cancel = true;
}
ColNum++;
if (ColNum == 7)
e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
}
*/


        /*private void ShowReviews(object sender, RoutedEventArgs e)
        {
            TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;

            TourReviews tourReviews = new TourReviews(LoggedInGuide, selectedTour.id);

            tourReviews.Show();
            Close();
        }

        private void ShowStatistics(object sender, RoutedEventArgs e)
        {
            TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;
            TourStatistics tourStatistics = new TourStatistics(selectedTour.id, selectedTour.Name);

            tourStatistics.Show();
        }*/

        /*private TourGuestsDto GetBestTour()
        {
            string time = ComboBox1.Text;
            TourGuestsDto dto = TourController.GetMostVisitedTour(LoggedInGuide.Id, time);

            return dto;

        }

        private void ShowBestStatistics(object sender, RoutedEventArgs e)
        {
            //TourStatistics tourStatistics = new TourStatistics(tour.Id , tour.Name);
            //tourStatistics.Show();
            BestTourStatistics tourStatistics = new BestTourStatistics(GetBestTour());
            tourStatistics.Show();


        }*/
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

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }


        private void ShowFirstCreateTourView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide));
        }

        private void ShowTourRequests(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourRequestsView(LoggedInGuide));
        }

        private void CreateReport(object sender, RoutedEventArgs e)
        {
            if (DataGridTours.SelectedItem != null)
            {
                TourBasicInfoDto selectedTour = (TourBasicInfoDto)DataGridTours.SelectedItem;
                PrintInvoice invoice = new PrintInvoice(selectedTour);
                invoice.DataReady += PrintInvoiceWindow_DataReady;

                invoice.Show();
                ShowDimmedOverlay();
            }
        }
        private void PrintInvoiceWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
        }

        private void ShowBestTourWindow(object sender, RoutedEventArgs e)
        {
            BestTourTimePickerWindow timePickerWindow = new BestTourTimePickerWindow(LoggedInGuide);
            timePickerWindow.DataReady += BestTourTimePickerWindow_DataReady;
            timePickerWindow.DataReady2 += BestTourTimePickerWindowClose_DataReady;
            timePickerWindow.Show();
            ShowDimmedOverlay();
        }

        private void ShowSuperVodic(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SuperGuideView(LoggedInGuide));
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
