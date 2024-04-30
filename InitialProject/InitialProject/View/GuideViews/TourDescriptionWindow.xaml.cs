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
    /// Interaction logic for TourDescriptionWindow.xaml
    /// </summary>
    public partial class TourDescriptionWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;
        public TourDescriptionWindow(string description)
        {
            this.DataContext = this;
            InitializeComponent();
            TextBlock.Text = description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
