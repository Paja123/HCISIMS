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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for ComplexTourSpecificsWindow.xaml
    /// </summary>
    public partial class ComplexTourSpecificsWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;
        public event EventHandler<DataEventArgs> DataReadyTourRequest;
        public User LoggedInGuide { get; set; }
        public List<TourRequest> Requests { get; set; }
        public List<string> RequestCities { get; set; } = new List<string>();
        public ComplexTourRequest _SelectedComplexTourRequest { get; set; }
        public ComplexTourRequestController ComplexTourRequestController = new ComplexTourRequestController();
        public TourController TourController = new TourController();
        public TourRequestController TourRequestController = new TourRequestController();

        public ComplexTourSpecificsWindow(User user, ComplexTourRequest _selectedComplexTourRequest)
        {
            LoggedInGuide = user;
            Requests = _selectedComplexTourRequest.Requests;
            _SelectedComplexTourRequest = _selectedComplexTourRequest;
            AddRequestNames(_selectedComplexTourRequest.Requests);
            this.DataContext = this;
            InitializeComponent();
        }
        private void AddRequestNames(List<TourRequest> requests)
        {
            foreach (TourRequest request in requests)
            {
                RequestCities.Add(request.Location.City);
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideRest();

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

                Language.Content = request.Language;
                Country.Content = request.Location.Country;
                City.Content = request.Location.City;
                GuestNumber.Content = request.GuestNumber;
            }

        }

        private void HideRest()
        {
            if (ComboBox1.SelectedIndex == -1)
            {
                DateRow.Visibility = Visibility.Collapsed;
                CountryAndDescriptionRow.Visibility = Visibility.Collapsed;
                CityRow.Visibility = Visibility.Collapsed;
                LanguageRow.Visibility = Visibility.Collapsed;
                GuestsRow.Visibility = Visibility.Collapsed;
                AcceptButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                DateRow.Visibility = Visibility.Visible;
                CountryAndDescriptionRow.Visibility = Visibility.Visible;
                CityRow.Visibility = Visibility.Visible;
                LanguageRow.Visibility = Visibility.Visible;
                GuestsRow.Visibility = Visibility.Visible;
                AcceptButton.Visibility = Visibility.Visible;
            }
        }
        private TourRequest GetTourByCityName(string selectedCity)
        {

            return Requests.FirstOrDefault(x => x.Location.City.Equals(selectedCity));
        }

        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            if (DatePicker1.SelectedDate !=null && ComboBox1.SelectedItem != null)
            {
                string selectedCity = (string)ComboBox1.SelectedItem;
                TourRequest request = GetTourByCityName(selectedCity);
                DateTime selectedDate = (DateTime)DatePicker1.SelectedDate;

                TourRequestController.Accept(request.Id, selectedDate);
                _SelectedComplexTourRequest.Guides.Add(LoggedInGuide);
                RaiseDataReadyTourRequestEvent(request);
                RaiseDataReadyEvent(true);
              ComplexTourRequestController.SetGuide(_SelectedComplexTourRequest.Id, LoggedInGuide);

                this.Close();
            }
            
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            //i oni argumeni
            RaiseDataReadyEvent(true);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TourRequest _selectedTourRequest = GetTourByCityName((string)ComboBox1.SelectedItem);
            TourDescriptionWindow tourDescriptionWindow= new TourDescriptionWindow(_selectedTourRequest.Description);
            tourDescriptionWindow.DataReady += tourDescriptionWindow_DataReady;
            tourDescriptionWindow.Show();
        }
        private void tourDescriptionWindow_DataReady(object sender, DataEventArgs e)
        {
            HideDimmedOverlay();

        }
        private void ShowDimmedOverlay()
        {
            DimmedOverlay1.Visibility = Visibility.Visible;
        }

        private void HideDimmedOverlay()
        {
            DimmedOverlay1.Visibility = Visibility.Collapsed;
        }

        private void DimmedOverlay_Click(object sender, RoutedEventArgs e)
        {
            HideDimmedOverlay();
        }
        private void RaiseDataReadyEvent(bool closeWindow)
        {
            DataReady?.Invoke(this, new DataEventArgs(closeWindow));
        }
        private void RaiseDataReadyTourRequestEvent(TourRequest acceptedRequest)
        {
            DataReadyTourRequest?.Invoke(this, new DataEventArgs(acceptedRequest));
        }
    }
}
