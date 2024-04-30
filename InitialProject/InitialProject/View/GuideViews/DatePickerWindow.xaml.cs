using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for DatePickerWindow.xaml
    /// </summary>
    public partial class DatePickerWindow : Window
    {
        public TourRequest Request { get; set; }
        public event EventHandler<DataEventArgs> DataReady;
        public TourRequestController TourRequestController { get; set; }
        public DatePickerWindow(DateTime selectedLowerDateLimit, DateTime selectedUpperDateLimit, List<DateTime> occupiedDates, TourRequest request)
        {
            Request = request;
            this.DataContext = this;
            InitializeComponent();
            DatePicker1.BlackoutDates.Clear();
            DatePicker1.DisplayDateStart = selectedLowerDateLimit;
            DatePicker1.DisplayDateEnd = selectedUpperDateLimit;
            DatePicker1.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(0001, 1, 1), selectedLowerDateLimit.AddDays(-1)));
            DatePicker1.BlackoutDates.Add(
                new CalendarDateRange(selectedUpperDateLimit.AddDays(1), new DateTime(9999, 1, 1)));
            foreach (DateTime date in occupiedDates)
            {
                DatePicker1.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            if (DatePicker1.Text != String.Empty)
            {
                Request.SelectedDate = DatePicker1.DisplayDate.Date;

                RaiseDataReadyEvent(Request);
                this.Close();
            }
            
        }
        private void RaiseDataReadyEvent(TourRequest request)
        {
            DataReady?.Invoke(this, new DataEventArgs(request));
        }
    }
}
