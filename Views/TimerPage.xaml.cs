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
        #region private members

        private MainContent _parent;

        #endregion private members
        //#############################################################################
        #region constructor

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public TimerPage(MainContent parent)
        {
            InitializeComponent();
            DataContext = new TimerPageViewModel();
            _parent = parent;
        }

        #endregion constructor
        //#############################################################################
        #region event handler

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ((TimerPageViewModel)DataContext).StartTimer();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ((TimerPageViewModel)DataContext).StopTimer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _parent.OpenCreateProject();
        }

        #endregion event handler
        //#############################################################################
        #region private methods

        private void ResetTimerDispatcher()
        {
            ((TimerPageViewModel)DataContext).ResetTimer();
        }

        #endregion private methods
    }
}
