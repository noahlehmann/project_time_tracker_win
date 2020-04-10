using ProjectTimeTrackerWPF.ViewModels;
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
using System.Windows.Threading;

namespace ProjectTimeTrackerWPF.Views
{
    /// <summary>
    /// Interaktionslogik für TimerPage.xaml
    /// </summary>
    public partial class TimerPage : Page
    {
        #region constructor

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public TimerPage()
        {
            InitializeComponent();
            DataContext = new TimerPageViewModel();
        }

        #endregion constructor
        //#############################################################################
        #region timer buttons

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ((TimerPageViewModel)DataContext).StartTimer();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ((TimerPageViewModel)DataContext).StopTimer();
        }

        private void ResetTimerDispatcher()
        {
            ((TimerPageViewModel)DataContext).ResetTimer();
        }

        #endregion timer buttons

    }
}
