using ProjectTimeTrackerWPF.ViewModels;
using ProjectTimeTrackerWPF.Views;
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

namespace project_time_tracker_win
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Top = SystemParameters.PrimaryScreenHeight - Height - 50;
            // Left = SystemParameters.PrimaryScreenWidth - Width - 50;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = new MainWindowViewModel();
            ContentFrame.Navigate(new MainContent());
            Console.WriteLine(System.Windows.SystemParameters.PrimaryScreenWidth);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
