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
using InitialProject.View.Guide;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for RequestStatisticsView.xaml
    /// </summary>
    public partial class RequestStatisticsView : Page
    {
        private User LoggedInGuide { get; set; }

        public ObservableCollection<TourRequest> FilteredRequests { get; set; } =
            new ObservableCollection<TourRequest>();

        public TourRequestController TourRequestController { get; set; } = new TourRequestController();
        public TourController TourController { get; set; } = new TourController();
        public List<TourRequest> Requests { get; set; }
        public List<TourRequest> AllRequests { get; set; }

        public ObservableCollection<TourRequestYearlyCountDto> RequestYearlyCounts { get; set; }
        public RequestStatisticsView(List<TourRequest> allRequests)
        {
            AllRequests = allRequests;
            this.DataContext = this;
            RequestYearlyCounts = GetYearlyRequests(AllRequests);


            InitializeComponent();
            YearlyDataGrid.ItemsSource = RequestYearlyCounts;
            TextBlock.Text =
                "Odaberite godinu u rezultatima i dodirnite dugme : ,,Prikaži rezultate po mesecima kako biste videli broj zahteva po mesecima u toj godini.";
            TextBlock2.Text =
                "Najtraženija lokacija ili jezik se posmatra na osnovu zahteva za turama napravljenih u poseldnjih godinu dana";


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

        public ObservableCollection<TourRequestYearlyCountDto> GetYearlyRequests(List<TourRequest> requests)
        {
            List<TourRequestYearlyCountDto> count = new List<TourRequestYearlyCountDto>();
            List<int> uniqueYears = new List<int>();
            foreach (TourRequest request in requests)
            {
                int year = request.LowerDateLimit.Date.Year;
                if (!uniqueYears.Contains(year))
                {
                    uniqueYears.Add(year);
                    count.Add(new TourRequestYearlyCountDto(year, request.LowerDateLimit));
                }
                else
                {
                    TourRequestYearlyCountDto dto = count.FirstOrDefault(t => t.Year == year);
                    dto.Count++;
                    dto.Dates.Add(request.LowerDateLimit.Date);
                }
            }

            return new ObservableCollection<TourRequestYearlyCountDto>(count);

        }


        private void ShowMonthly(object sender, RoutedEventArgs e)
        {
            if (YearlyDataGrid.SelectedItem != null)
            {
                TourRequestYearlyCountDto request = (TourRequestYearlyCountDto)YearlyDataGrid.SelectedItem;
                MonthlyRequestsWindow monthlyRequestsWindow = new MonthlyRequestsWindow(request);
                monthlyRequestsWindow.DataReady += MonthlyRequestsWindowOnDataReady;
                monthlyRequestsWindow.Show();
                ShowDimmedOverlay();
            }
          
        }

        private void MonthlyRequestsWindowOnDataReady(object? sender, DataEventArgs e)
        {
            HideDimmedOverlay();
        }


        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //FilterButton.Visibility = Visibility.Visible;
            FilterButton.Visibility = Visibility.Visible;
            if (ComboBox1.SelectedIndex == 0) // Option 1 is selected
            {
                CountryLabel.Visibility = Visibility.Visible;
                InputCountry.Visibility = Visibility.Visible;
                CityLabel.Visibility = Visibility.Visible;
                InputCity.Visibility = Visibility.Visible;

                LanguageLabel.Visibility = Visibility.Collapsed;
                InputLanguage.Visibility = Visibility.Collapsed;
                InputLanguage.Text = String.Empty;


                FilterByLocation(InputCountry.Text.ToLower(), InputCity.Text.ToLower());
            }
            else if (ComboBox1.SelectedIndex == 1)
            {
                CountryLabel.Visibility = Visibility.Collapsed;
                InputCountry.Visibility = Visibility.Collapsed;
                InputCountry.Text = String.Empty;
                CityLabel.Visibility = Visibility.Collapsed;
                InputCity.Visibility = Visibility.Collapsed;
                InputCity.Text = String.Empty;

                LanguageLabel.Visibility = Visibility.Visible;
                InputLanguage.Visibility = Visibility.Visible;

                FilterByLanguage(InputLanguage.Text.ToLower());

            }
        }
        private List<TourRequest> FilterByLanguage(string inputLanguage)
        {
            return AllRequests.Where(r => r.Language.ToLower().Equals(inputLanguage)).ToList();
        }

        private List<TourRequest> FilterByLocation(string inputCountry, string inputCity)
        {
            if (inputCountry != String.Empty && inputCity != String.Empty)
            {
                return AllRequests.Where(r =>
                        r.Location.Country.ToLower().Equals(inputCountry) &&
                        r.Location.City.ToLower().Equals(inputCity))
                    .ToList();
            }

            if (inputCountry != String.Empty && inputCity == String.Empty)
            {
                return AllRequests.Where(r => r.Location.Country.ToLower().Equals(inputCountry)).ToList();
            }

            if (inputCountry == String.Empty && inputCity != String.Empty)
            {
                return AllRequests.Where(r => r.Location.City.ToLower().Equals(inputCity)).ToList();
            }

            return AllRequests;
        }

        private void UpdateYearly(object sender, RoutedEventArgs e)
        {
            List<TourRequest> requests = new List<TourRequest>();

            if (!(InputCountry.Text == String.Empty &&
                  InputCity.Text == String.Empty & InputLanguage.Text == String.Empty))
            {
                if (InputLanguage.Text != String.Empty)
                {
                    requests = FilterByLanguage(InputLanguage.Text.ToLower());
                }
                else
                {
                    requests = FilterByLocation(InputCountry.Text.ToLower(), InputCity.Text.ToLower());
                }
            }
            else
            {
                requests = AllRequests;
            }

            ObservableCollection<TourRequestYearlyCountDto> filteredYearlyDtos = GetYearlyRequests(requests);
            YearlyDataGrid.ItemsSource = filteredYearlyDtos;


        }

        private void CreateNewTourByLocation(object sender, RoutedEventArgs e)
        {
            Location hottestLocation = TourRequestController.GetHottestLocation();

            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide, hottestLocation));
            
        }
        private void CreateNewTourByLanguage(object sender, RoutedEventArgs e)
        {

            string hottestLanguage = TourRequestController.GetHottestLanguage();

            NavigationService?.Navigate(new CreateTourFirstView(LoggedInGuide,hottestLanguage));

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

        private void QuitJob(object sender, RoutedEventArgs e)
        {
            TourController.Quit(LoggedInGuide);
            NavigationService?.Navigate(new LoginView());
        }

        private void ShowHistoryView(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TourHistoryView(LoggedInGuide));
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

    }
}
