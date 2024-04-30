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
    /// Interaction logic for RequestsFilterWindow.xaml
    /// </summary>
    public partial class RequestsFilterWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;
        public TourRequest TourRequest = new TourRequest();
        public RequestsFilterWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            Country.Text = String.Empty;
            City.Text = String.Empty;
            GuestsNumber.Text = String.Empty;
            Language.Text = String.Empty;
            LowerDateLimit.Text = String.Empty;
            UpperDateLimit.Text = String.Empty;
            

           
        }


        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            TourRequestFilter filter = new TourRequestFilter();

            if (Country.Text != String.Empty)
            {
                filter.Country = Country.Text;
            }

            if (City.Text != String.Empty)
            {
                filter.City = City.Text;
            }

            if (Language.Text != String.Empty)
            {
                filter.Language = Language.Text;
            }

            if (GuestsNumber.Text != String.Empty)
            {
                filter.GuestNumber = Int32.Parse(GuestsNumber.Text);
            }

            if (LowerDateLimit.Text != String.Empty)
            {
                filter.LowerDateLimit = LowerDateLimit.DisplayDate;
            }

            if (UpperDateLimit.Text != String.Empty)
            {
                filter.UpperDateLimit = UpperDateLimit.DisplayDate;
            }

            RaiseDataReadyEvent(filter);

            this.Close();
        }
        private void RaiseDataReadyEvent(TourRequestFilter filter)
        {
            DataReady?.Invoke(this, new DataEventArgs(filter));
        }

        private void ResetInputs(object sender, RoutedEventArgs e)
        {
            Country.Text = String.Empty;
            City.Text = String.Empty;
            GuestsNumber.Text = String.Empty;
            Language.Text = String.Empty;
            LowerDateLimit.Text = String.Empty;
            UpperDateLimit.Text = String.Empty;


        }
    }
}
