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
    /// Interaction logic for CommentPopUp.xaml
    /// </summary>
    public partial class CommentPopUp : Window
    {
        public CommentPopUp(string comment)
        {
            InitializeComponent();
            TextBlock.Text = comment;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
