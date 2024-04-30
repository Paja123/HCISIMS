using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for TourRequestsView.xaml
    /// </summary>
    public partial class TourRequestsView : Page
    {
        private User LoggedInGuide { get; set; }

        public ObservableCollection<TourRequest> FilteredRequests { get; set; } =
            new ObservableCollection<TourRequest>();

        public TourRequestController TourRequestController { get; set; } = new TourRequestController();
        public TourController TourController { get; set; } = new TourController();
        public List<TourRequest> Requests { get; set; }
        public List<TourRequest> AllRequests { get; set; }
        public TourRequestFilter Filters { get; set; }


        public TourRequestsView(User user)
        {
             this.DataContext = this;
            LoggedInGuide = user;

            Requests = TourRequestController.GetAllPending();
            AllRequests = TourRequestController.GetAll();
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RoutedEventArgs routedEventArgs)
        {
            NavigationService?.Navigate(new ComplexTourRequestView(LoggedInGuide));
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

        private void DataGridRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            RequestsFilterWindow requestsFilterWindow = new RequestsFilterWindow();
            requestsFilterWindow.DataReady += requestsFilterWindow_DataReady;

            ShowDimmedOverlay();
            requestsFilterWindow.ShowDialog();

        }
        private void requestsFilterWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
            Filters= e.Request;
            // Process the data received from the popup window
            ApplyFilters();

        }

        private void ApplyFilters()
        {
            List<TourRequest> result = Requests;
            String country = Filters.Country;
            String city = Filters.City;
            String language = Filters.Language;


            if (country != String.Empty)
            {
                result.RemoveAll(tr => !tr.Location.Country.Equals(country));
            }

            if (city != String.Empty)
            {
                result.RemoveAll(tr => !tr.Location.City.Equals(city));
            }

            if (language != String.Empty)
            {
                result.RemoveAll(tr => !tr.Language.Equals(language));
            }

            if (Filters.GuestNumber != Int32.MinValue)
            {
                if (Filters.GuestNumber > 0)
                {
                    result.RemoveAll(tr => tr.GuestNumber < Filters.GuestNumber);
                }

            }

            if (Filters.LowerDateLimit != DateTime.MinValue)
            {
                result.RemoveAll(tr => tr.LowerDateLimit.Date.CompareTo(Filters.LowerDateLimit.Date) < 0);
            }

            if (Filters.UpperDateLimit != DateTime.MinValue)
            {
                result.RemoveAll(tr => tr.UpperDateLimit.Date.CompareTo(Filters.UpperDateLimit.Date) > 0);
            }


            FilteredRequests = new ObservableCollection<TourRequest>(result);
            DataGridRequests.ItemsSource = FilteredRequests;
        }

        private void ShowRequestStatisticsView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RequestStatisticsView(AllRequests));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRequests.SelectedItem != null)
            {
                TourRequest selected = (TourRequest)DataGridRequests.SelectedItem;
                List<DateTime> occupiedDates = TourController.GetOccupiedDays(LoggedInGuide.Id, selected.LowerDateLimit, selected.UpperDateLimit);

                DatePickerWindow datePickerWindow = new DatePickerWindow(selected.LowerDateLimit, selected.UpperDateLimit, occupiedDates, selected);
                datePickerWindow.DataReady += datePickerWindow_DataReady;

                datePickerWindow.Show();
                ShowDimmedOverlay();
            }
           
        }
        private void datePickerWindow_DataReady(object sender, DataEventArgs e)
        {
            TourRequest acceptedTourRequest = e.AcceptedTourRequest;
            // Process the data received from the popup window
            TourRequestController.Accept(acceptedTourRequest.Id, acceptedTourRequest.SelectedDate);
            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide, acceptedTourRequest));

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

        private void ShowActiveTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void ShowTodaysToursView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));
        }

        private void ShowHistroy(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
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
