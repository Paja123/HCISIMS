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
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for CreateTourSecondView.xaml
    /// </summary>
    public partial class CreateTourSecondView : Page
    {
        public User LoggedInGuide { get; set; }
        public TourToControllerDto tourToControllerDto { get; set; }
        public string KeyPointNames { get; set; }
        public List<string> separateNames = new List<String>();


        public CreateTourSecondView(TourToControllerDto dto, User user)
        {
            tourToControllerDto = dto;
            LoggedInGuide = user;
            this.DataContext = dto;
            InitializeComponent();

            TextBox.Text = KeyPointNames;

        }

        private void CancelTour(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            separateNames.Add(TextBox.Text);
            KeyPointNames = KeyPointNames + System.Environment.NewLine + TextBox.Text;

            TextBlock.Text = KeyPointNames;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tourToControllerDto.TourKeyPointNames = separateNames;
            if (separateNames.Count >= 2)
            {
                NavigationService?.Navigate(new CreateTourThirdView(tourToControllerDto, LoggedInGuide));
            }

            
        }
    }
}
