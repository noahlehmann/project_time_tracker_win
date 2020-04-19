using project_time_tracker_win;
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

namespace ProjectTimeTrackerWPF.Views
{
    /// <summary>
    /// Interaktionslogik für Options.xaml
    /// </summary>
    public partial class Options : Page
    {

        private MainWindow _parent;

        public Options(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ExitOptions();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExitOptions();
        }

        private void ExitOptions()
        {
            _parent.ContentFrame.GoBack();
        }
    }
}
