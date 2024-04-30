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

namespace InitialProject.View.GuideViews
{
    /// <summary>
    /// Interaction logic for CommentDialog.xaml
    /// </summary>
    public partial class CommentDialog : UserControl
    {
        public CommentDialog(string comment)
        {
            TextBlock.Text = comment;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
