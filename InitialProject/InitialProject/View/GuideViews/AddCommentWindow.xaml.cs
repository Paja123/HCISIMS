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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InitialProject.Dto;
using InitialProject.Model;

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for AddCommentWindow.xaml
    /// </summary>
    public partial class AddCommentWindow : Window
    {
        public event EventHandler<DataEventArgs> DataReady;
        public TourToControllerDto Dto { get; set; }
        public AddCommentWindow(TourToControllerDto dto)
        {

            Dto = dto;
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dto.Description = TextBlock.Text;
            RaiseDataReadyEvent(Dto);
            
            this.Close();
        }
        private void RaiseDataReadyEvent(TourToControllerDto dto)
        {
            DataReady?.Invoke(this, new DataEventArgs(dto));
        }
    }
}
