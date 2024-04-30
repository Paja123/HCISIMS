using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateTourFirstView.xaml
    /// </summary>
    public partial class CreateTourFirstView : Page, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CreateTourFirstView(User user)
        {
            LoggedInGuide = user;

            DataContext = this;

            InitializeComponent();
            StartDate.DisplayDateStart = DateTime.Today;
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int number;
        private string time;
        private string text;
        private string _test1;
        private string _test2;
        private string _test3;
        private string _test4;
        private string _test5;
        private string _test6;

        public string Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }
        public string Test2
        {
            get
            {
                return _test2;
            }
            set
            {
                if (value != _test2)
                {
                    _test2 = value;
                    OnPropertyChanged("Test2");
                }
            }
        }
        public string Test3
        {
            get
            {
                return _test3;
            }
            set
            {
                if (value != _test3)
                {
                    _test3 = value;
                    OnPropertyChanged("Test3");
                }
            }
        }
        public string Test4
        {
            get
            {
                return _test4;
            }
            set
            {
                if (value != _test4)
                {
                    _test4 = value;
                    OnPropertyChanged("Test4");
                }
            }
        }
        public string Test5
        {
            get
            {
                return _test5;
            }
            set
            {
                if (value != _test5)
                {
                    _test5 = value;
                    OnPropertyChanged("Test5");
                }
            }
        }
        public string Test6
        {
            get
            {
                return _test6;
            }
            set
            {
                if (value != _test6)
                {
                    _test6 = value;
                    OnPropertyChanged("Test5");
                }
            }
        }



        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public User LoggedInGuide { get; set; }
        public TourController TourController { get; set; } = new TourController();
        public TourKeyPointController TourKeyPointController { get; set; } = new TourKeyPointController();

        public TourToControllerDto tourToControllerDto { get; set; } = new TourToControllerDto();
       
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Number" && (Number <= 0))
                {
                    return "Please enter a positive number.";
                }
                else if (columnName == "Time" && !IsValidTimeFormat(Time))
                {
                    return "Please enter a valid time format (HH:MM:SS).";
                }
                else if (columnName == "Text" && !IsValidAlphabeticText(Text))
                {
                    return "Please enter alphabetic characters only.";
                }
                return null;
            }
        }
        private bool IsValidAlphabeticText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(text);
        }

        private bool IsValidTimeFormat(string time)
        {
            string pattern = @"^([0-1][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$";
            return Regex.IsMatch(time, pattern);
        }

        public CreateTourFirstView(User user,  Location location): this(user)
        {
            Country.Text = location.Country;
            City.Text = location.City;
        }
        public CreateTourFirstView(User user, string language) : this(user)
        {
            Language.Text = language;
        }
        public CreateTourFirstView(User user, TourRequest acceptedRequest) : this(user)
        {
            Language.Text = acceptedRequest.Language;
            Country.Text = acceptedRequest.Location.Country;
            City.Text = acceptedRequest.Location.City;
            StartDate.SelectedDate= acceptedRequest.SelectedDate;
            GuestLimit.Text = acceptedRequest.GuestNumber.ToString();
        }


        private void Create()
        {

            
            tourToControllerDto.Name = Name.Text;
            tourToControllerDto.Country = Country.Text;
            tourToControllerDto.City = City.Text;
            //OVO PROVERI JEL TREBA TAKO
            tourToControllerDto.Description = TextBlock.Text; 
            tourToControllerDto.Language = Language.Text;
            tourToControllerDto.GuestLimit = int.Parse(GuestLimit.Text);
            tourToControllerDto.StartDateAndTime = SetDateAndTime(StartDate.Text, StartTime.Text);
            tourToControllerDto.Duration = SetDuration(Duration.Text);
            tourToControllerDto.Guide = LoggedInGuide;

           
        }
        private String[] SeparateForDate(String names)
        {

            String[] delimiters = { ",", ";", ".", "/", };
            String[] result = names.Split(delimiters, StringSplitOptions.None);

            return result;
        }
        private DateTime SetDateAndTime(String dateString, String timeString)
        {
            String[] temp = SeparateForDate(dateString);
            String format = temp[1] + "-" + temp[0] + "-" + temp[2] + " " + timeString;

            //Myb put it in try catch 
            DateTime dateTime = DateTime.ParseExact(format, "d-M-yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            return dateTime;
        }

        private TimeSpan SetDuration(String timeInHours)
        {
            int hour = int.Parse(timeInHours);
            var startTime = new TimeOnly(hour, 00, 00);
            var start = new TimeSpan(hour, 00, 00);
            return start;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddCommentWindow addCommentWindow = new AddCommentWindow(tourToControllerDto);
            addCommentWindow.DataReady += addCommentWindow_DataReady;
            addCommentWindow.ShowDialog();

        }
        private void addCommentWindow_DataReady(object sender, DataEventArgs e)
        {
            tourToControllerDto.Description = e.Dto.Description;
            // Process the data received from the popup window
            TextBlock.Text = e.Dto.Description;
        }

        private void GoToSecondStep(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ValidationError> e1 = new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(Name));
            ObservableCollection<ValidationError> e2= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(Country));
            ObservableCollection<ValidationError> e3= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(City));
            ObservableCollection<ValidationError> e4= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(Language));
            ObservableCollection<ValidationError> e5= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(StartDate));
            ObservableCollection<ValidationError> e6= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(StartTime));
            ObservableCollection<ValidationError> e7= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(Duration));
            ObservableCollection<ValidationError> e8= new ObservableCollection<ValidationError>(System.Windows.Controls.Validation.GetErrors(GuestLimit));



            /* if (string.IsNullOrEmpty(this["Number"]) && string.IsNullOrEmpty(this["Time"]) && Name.Text != String.Empty)
          {
              Create();
              NavigationService?.Navigate(new CreateTourSecondView(tourToControllerDto, LoggedInGuide));
          }
          */
            if (e1.Count == 0 && e2.Count == 0 && e3.Count == 0 && e4.Count == 0 && e5.Count == 0 && e6.Count == 0 && e7.Count == 0 && e8.Count == 0 && StartDate.Text != String.Empty)
           {
               Create();
               NavigationService?.Navigate(new CreateTourSecondView(tourToControllerDto, LoggedInGuide));

            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();

        }

        private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void OpenTutorial(object sender, RoutedEventArgs e)
        {

            string url = "https://youtu.be/tYFe00iRmjM"; 

            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
