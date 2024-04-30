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
using InitialProject.Controller;
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for TouristCheckingView.xaml
    /// </summary>
    public partial class TouristCheckingView : Window
    {

        public ObservableCollection<TourReservation> Reservations{ get; set; }
        public TourReservationController TourReservationController { get; set; } = new TourReservationController();
        public TourKeyPoint _lastCheckedKeyPoint { get; set; }
        public event EventHandler<DataEventArgs> DataReady;



        public TouristCheckingView(ObservableCollection<TourReservation> reservations, TourKeyPoint lastCheckedKeyPoint)
        {
            Reservations= reservations;
            _lastCheckedKeyPoint = lastCheckedKeyPoint;
            this.DataContext = this;
            InitializeComponent();
        }

        
        private void SetArrivalKeyPoint(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            TourReservation reservation = (TourReservation)checkBox.DataContext;
            TourReservationController.SetArrivalKeyPoint(_lastCheckedKeyPoint, reservation.Id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dodaj i ono sa resource za showDimmed
            bool closeDimmedScreen = true;
            RaiseDataReadyEvent(closeDimmedScreen);

            this.Close();
        }
        private void RaiseDataReadyEvent(bool closeDimmedScreen)
        {
            DataReady?.Invoke(this, new DataEventArgs(closeDimmedScreen));
        }
    }
}
