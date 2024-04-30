using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;

namespace InitialProject.View.GuideViews
{

    public partial class CreateTourThirdView : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _test1;

        public string Test1
        {
            get { return _test1; }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }

        public User LoggedInGuide { get; set; }
        public TourToControllerDto tourToControllerDto { get; set; }
        public TourController TourController { get; set; } = new TourController();
        public TourKeyPointController TourKeyPointController { get; set; } = new TourKeyPointController();
        public string Urls { get; set; }
        public List<string> separateUrls = new List<String>();

        public CreateTourThirdView(TourToControllerDto dto, User user)
        {
            LoggedInGuide = user;
            tourToControllerDto = dto;
            this.DataContext = this;
            InitializeComponent();
            TextBlockPop.Text =
                "Kada na Internetu nađete sliku koju želite dodeliti Vašoj turi, zadržite je prstom i pritisnite opciju: Kopiraj adresu slike (eng. Copy Image Address).Zatim se vratite u aplikaciju i zadržite polje za unos linka (URL) i pritisnite: Nalepi (eng. Paste).  ";

        }


        private void AddUrl(object sender, RoutedEventArgs e)
        {
            separateUrls.Add(TextBox.Text);
            Urls = Urls + System.Environment.NewLine + TextBox.Text;

            TextBlock.Text = Urls;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void CreateTour(object sender, RoutedEventArgs e)
        {
            tourToControllerDto.ImageURLs = separateUrls;
            Tour newTour = TourController.Create(tourToControllerDto);
            List<TourKeyPoint> newKeyPoints =
                TourKeyPointController.Create(tourToControllerDto.TourKeyPointNames, newTour);
            TourController.UpdateTourProperties(newTour, tourToControllerDto, newKeyPoints);

            NavigationService?.Navigate(new ActiveToursView(LoggedInGuide));
        }

        private void AddFromDevice(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                string destinationFolder = @"C:\Users\Pavle\Desktop\HCI_PROJEKAT\InitialProject\InitialProject\Images\";
                string fileName = System.IO.Path.GetFileName(selectedFileName);
                string destinationPath = System.IO.Path.Combine(destinationFolder, fileName);

                System.IO.File.Copy(selectedFileName, destinationPath);
            }
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

        private void ShowDimmedOverlay()
        {
            DimmedOverlay.Visibility = Visibility.Visible;
        }

        private void HideDimmedOverlay()
        {
            DimmedOverlay.Visibility = Visibility.Collapsed;
        }
        private void DimmedOverlay_Click(object sender, RoutedEventArgs e)
        {
            HideDimmedOverlay();
            if (MyPopover.IsOpen)
            {
                MyPopover.IsOpen = false;
            }
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

    }
}
