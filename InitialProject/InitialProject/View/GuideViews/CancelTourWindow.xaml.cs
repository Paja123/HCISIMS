using InitialProject.Dto;
using InitialProject.Model;
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

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for CancelTourWindow.xaml
    /// </summary>
    public partial class CancelTourWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;
        public event EventHandler<DataEventArgs> DataReadyClose;
        public TourBasicInfoDto Tour { get; set; }

        public CancelTourWindow(TourBasicInfoDto tour)
        {
            Tour = tour;
            this.DataContext = this;
            InitializeComponent();
            TourName.Content = tour.Name;
        }

        private void RaiseDataReadyEvent(TourBasicInfoDto tour)
        {
            DataReady?.Invoke(this, new DataEventArgs(tour));
        }
        private void RaiseDataReadyCloseEvent(bool positive)
        {
            DataReadyClose?.Invoke(this, new DataEventArgs(positive));
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            RaiseDataReadyEvent(Tour);
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            RaiseDataReadyCloseEvent(true);

            this.Close();
        }
    }
}
