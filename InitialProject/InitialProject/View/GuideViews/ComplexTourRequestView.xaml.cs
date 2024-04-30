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
    /// Interaction logic for ComplexTourRequestView.xaml
    /// </summary>
    public partial class ComplexTourRequestView : Page
    {
        public User LoggedInGuide { get; set; }
        public ComplexTourRequestController ComplexTourRequestController = new ComplexTourRequestController();
        public TourController TourController = new TourController();
        public TourRequestController TourRequestController = new TourRequestController();

        public List<ComplexTourRequest> Requests { get; set; }
        public List<string> RequestCities { get; set; } = new List<string>();
        public ComplexTourRequest _SelectedComplexTourRequest { get; set; }
        public ComplexTourRequestView(User user)
        {

            LoggedInGuide = user;
            Requests = GetAvailableComplexTours(user);
            this.DataContext = this;

            InitializeComponent();
            TextBlock.Text = "Ovo su zahtevi za složene ture koje su poslali gosti. Složena tura sastoji se od više različitih tura.";
        }
        private List<ComplexTourRequest> GetAvailableComplexTours(User user)
        {
            List<ComplexTourRequest> complexTourRequests = ComplexTourRequestController.GetAllPending();
            List<ComplexTourRequest> availableTourRequests = new List<ComplexTourRequest>();
            availableTourRequests.AddRange(complexTourRequests);
            foreach (ComplexTourRequest complexTour in complexTourRequests)
            {
                if (AvailabilityCheck(complexTour))
                {
                    availableTourRequests.Remove(complexTour);
                }
            }

            return availableTourRequests;
        }

        private bool AvailabilityCheck(ComplexTourRequest complexTour)
        {
            List<int> guidesIds = getGuidesIds(complexTour);
            if (guidesIds.Contains(LoggedInGuide.Id))
                return true;
            return false;

        }

        private List<int> getGuidesIds(ComplexTourRequest complexTour)
        {
            List<int> ids = new List<int>();
            foreach (User guide in complexTour.Guides)
            {
                ids.Add(guide.Id);
            }
            return ids;
        }

        private void AddRequestNames(List<TourRequest> requests)
        {
            foreach (TourRequest request in requests)
            {
                RequestCities.Add(request.Location.City);
            }
        }



        private void DataGridRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridRequests.SelectedItem != null)
            {
                _SelectedComplexTourRequest = (ComplexTourRequest)DataGridRequests.SelectedItem;
                AddRequestNames(_SelectedComplexTourRequest.Requests);
            }


        }

      /*  private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCity = (string)ComboBox1.SelectedItem;

            TourRequest request = GetTourByCityName(selectedCity);
            List<DateTime> occupiedDates = new List<DateTime>();
            if (request != null)
            {
                occupiedDates = TourController.GetOccupiedDays(LoggedInGuide.Id, request.LowerDateLimit, request.UpperDateLimit);
                DatePicker1.DisplayDateStart = request.LowerDateLimit;
                DatePicker1.DisplayDateEnd = request.UpperDateLimit;

                DatePicker1.BlackoutDates.Clear();
                DatePicker1.BlackoutDates.Add(
                    new CalendarDateRange(new DateTime(0001, 1, 1), request.LowerDateLimit.AddDays(-1)));
                DatePicker1.BlackoutDates.Add(
                    new CalendarDateRange(request.UpperDateLimit.AddDays(1), new DateTime(9999, 1, 1)));
                foreach (DateTime date in occupiedDates)
                {
                    DatePicker1.BlackoutDates.Add(new CalendarDateRange(date));
                }
            }

        }
      */

        private TourRequest GetTourByCityName(string selectedCity)
        {

            return _SelectedComplexTourRequest.Requests.FirstOrDefault(x => x.Location.City.Equals(selectedCity));
        }
        /*
        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            string selectedCity = (string)ComboBox1.SelectedItem;
            TourRequest request = GetTourByCityName(selectedCity);
            DateTime selectedDate = (DateTime)DatePicker1.SelectedDate;

            TourRequestController.Accept(request.Id, selectedDate);
            _SelectedComplexTourRequest.Guides.Add(LoggedInGuide);
            ComplexTourRequestController.SetGuide(_SelectedComplexTourRequest.Id, LoggedInGuide);

        }
    
         
         */
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

        private void ShowGuideHistory(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
        }

        private void ShowTodaysTours(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TodayTours(LoggedInGuide));

        }

        private void ViewComplexTour(object sender, RoutedEventArgs e)
        {
            if (_SelectedComplexTourRequest != null)
            {
                ComplexTourSpecificsWindow specificsWindow =
                    new ComplexTourSpecificsWindow(LoggedInGuide, _SelectedComplexTourRequest);
                specificsWindow.DataReady += ComplexTourSpecificsWindow_DataReady;
                specificsWindow.DataReadyTourRequest += ComplexTourSpecificsWindow_DataReadyTourRequest;
                ShowDimmedOverlay();
                specificsWindow.Show();
            }
            
        }
        private void ComplexTourSpecificsWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
        }
        private void ComplexTourSpecificsWindow_DataReadyTourRequest(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();
            TourRequest acceptedRequest = e.AcceptedTourRequest;
            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide, acceptedRequest));
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
