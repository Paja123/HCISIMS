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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for BestTourTimePickerWindow.xaml
    /// </summary>
    public partial class BestTourTimePickerWindow : Window
    {
        
        public event EventHandler<DataEventArgs> DataReady;
        public event EventHandler<DataEventArgs> DataReady2;

        private User LoggedInGuide { get; set; }

        public ObservableCollection<string> TourYears { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<TourBasicInfoDto> BasicTours { get; set; } =
            new ObservableCollection<TourBasicInfoDto>();

        public TourController TourController { get; set; } = new TourController();
        public Tour BestTour { get; set; }

        public BestTourTimePickerWindow(User user)
        {
            LoggedInGuide = user;
            this.DataContext = this;
            List<TourBasicInfoDto> tours = GetFinishedTours(LoggedInGuide.Id);

            GetTourYears(tours);
            InitializeComponent();

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

            TourYears.Add("oduvek");
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

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ErrorText.Visibility = Visibility.Collapsed;
            ComboBox1.BorderBrush = Brushes.White;
            ComboBox1.BorderThickness = new Thickness(1);
            string selection = (string)ComboBox1.SelectedItem;
            BestTour = TourController.GetMostVisitedTourSimple(LoggedInGuide.Id, selection);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            DataReady2?.Invoke(this, new DataEventArgs(true));
            this.Close();
        }

        private void ShowBestTour(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedItem == null)
            {
                ComboBox1.BorderBrush = Brushes.Red;
                ComboBox1.BorderThickness = new Thickness(3);
                ErrorText.Visibility = Visibility.Visible;

            }
            else
            {
                // If an item is selected, reset the border brush to its default value
                ComboBox1.ClearValue(Control.BorderBrushProperty);
                RaiseDataReadyEvent(BestTour);
                this.Close();
            }
        }

        private void RaiseDataReadyEvent(Tour tour)
        {
            DataReady?.Invoke(this, new DataEventArgs(tour));

        }
        
    }
}
