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
using System.Windows.Shapes;
using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for PrintInvoice.xaml
    /// </summary>
    public partial class PrintInvoice : Window
    {
        public event EventHandler<DataEventArgs> DataReady;

        public TourController TourController { get; set; } = new TourController();
        public TourReservationController TourReservationController { get; set; } = new TourReservationController();

        public TourBasicInfoDto Tour
        {get; set;}
        public List<TourReservation> TourReservations { get; set;} = new List<TourReservation>();
        public List<TourKeyPoint> KeyPoints { get; set; } = new List<TourKeyPoint>();
        public List<User> Tourists { get; set; } = new List<User>();
        public List<string> GuestNumbers { get; set; } = new List<string>();
        public PrintInvoice(TourBasicInfoDto selectedTour)
        {
            Tour = selectedTour;
            Tour tour = TourController.GetById(Tour.id);
            KeyPoints = tour.TourKeyPoints;
            TourReservations  = TourReservationController.GetByTour(tour);
            foreach (TourReservation reservation in TourReservations)
            {
                Tourists.Add(reservation.BookingGuest);
            }

            GuestNumbers = GetNumbers(TourReservationController.GetByTour(tour));
            InitializeComponent();
            TourName.Text = Tour.Name;
            Country.Text = Tour.Country;
            City.Text = Tour.City;
            Language.Text = Tour.Language;
            StartDate.Text = Tour.StartDateAndTime.Date.ToString();
            StartTime.Text = Tour.StartDateAndTime.TimeOfDay.ToString();
            GuestNubmer.Text = Tour.GuestLimit.ToString();
            Description.Text = tour.Description;
            GuideName.Text = tour.Guide.Username;
            this.DataContext = this;
          

        }

        private List<string> GetNumbers(List<TourReservation> reservations)
        {
            List<string> names = new List<string>();

            foreach (TourReservation reservation in reservations)
            {
                string input = "grupa od " + reservation.GuestNumber + " ljudi";
                names.Add(input);
            }
            return names;
        }

        private void DownloadPdf(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
            RaiseDataReadyEvent(true);
            this.Close();
        }
        private void RaiseDataReadyEvent(bool closedWindow)
        {
            DataReady?.Invoke(this, new DataEventArgs(closedWindow));
        }

        public void DownloadPdf1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
            RaiseDataReadyEvent(true);
            this.Close();
        }
    }
}
