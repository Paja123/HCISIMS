using InitialProject.Dto;
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
    /// Interaction logic for MonthlyRequestsWindow.xaml
    /// </summary>
    public partial class MonthlyRequestsWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;

        public ObservableCollection<MonthlyRequestsDto> Requests { get; set; }
        public int Year { get; set; }
        public MonthlyRequestsWindow(TourRequestYearlyCountDto yearlyCount)
        {
            this.DataContext = this;

            Requests = GetMonthlyRequests(yearlyCount);
            InitializeComponent();
        }
        public ObservableCollection<MonthlyRequestsDto> GetMonthlyRequests(TourRequestYearlyCountDto yearlyCount)
        {
            List<MonthlyRequestsDto> initialList = InitializeMonths();
            Year = yearlyCount.Year;
            yearlyCount.Dates.ForEach(date => initialList[date.Month - 1].Count++);

            return new ObservableCollection<MonthlyRequestsDto>(initialList);
        }

        private List<MonthlyRequestsDto> InitializeMonths()
        {
            List<MonthlyRequestsDto> requests = new List<MonthlyRequestsDto>();

            MonthlyRequestsDto january = new MonthlyRequestsDto("jan");
            MonthlyRequestsDto february = new MonthlyRequestsDto("feb");
            MonthlyRequestsDto march = new MonthlyRequestsDto("mar");
            MonthlyRequestsDto april = new MonthlyRequestsDto("apr");
            MonthlyRequestsDto may = new MonthlyRequestsDto("maj");
            MonthlyRequestsDto june = new MonthlyRequestsDto("jun");
            MonthlyRequestsDto july = new MonthlyRequestsDto("jul");
            MonthlyRequestsDto august = new MonthlyRequestsDto("avg");
            MonthlyRequestsDto september = new MonthlyRequestsDto("sept");
            MonthlyRequestsDto october = new MonthlyRequestsDto("okt");
            MonthlyRequestsDto november = new MonthlyRequestsDto("nov");
            MonthlyRequestsDto december = new MonthlyRequestsDto("dec");
            MonthlyRequestsDto[] months = { january, february, march, april, may, june, july, august, september, october, november, december };
            requests.AddRange(months);

            return requests;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseDataReadyEvent(true);
            this.Close();
        }
        private void RaiseDataReadyEvent(bool closeDimmed)
        {
            DataReady?.Invoke(this, new DataEventArgs(closeDimmed));
        }
    }
}
