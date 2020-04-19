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
    /// Interaktionslogik für MainContent.xaml
    /// </summary>
    public partial class MainContent : Page
    {

        private TimerPage _timerPage;

        public MainContent()
        {
            InitializeComponent();
            _timerPage = new TimerPage(this);
            LeftMainFrame.Navigate(_timerPage);
            RightMainFrame.Navigate(new StatisticsPage());
        }

        public void OpenCreateProject()
        {
            LeftMainFrame.Navigate(new CreateProject(this));
        }

        public void NavigateToTimerPage()
        {
            if (LeftMainFrame.CanGoBack)
            {
                LeftMainFrame.GoBack();
            }
            else
            {
                LeftMainFrame.Navigate(_timerPage);
            }
        }
    }
}
