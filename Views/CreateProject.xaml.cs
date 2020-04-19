using MaterialDesignThemes.Wpf;
using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Page
    {

        private MainContent _parent;       

        public CreateProject(MainContent parent)
        {
            InitializeComponent();
            DataContext = new CreateProjectViewModel();
            _parent = parent;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ProjectProperty> props = ((CreateProjectViewModel)DataContext).Properties;
            ((CreateProjectViewModel)DataContext).SaveProject();
            _parent.NavigateToTimerPage();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            _parent.NavigateToTimerPage();
        }

        private void AddPropertyBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Grid)((Button)sender).Parent);
            string key = ((TextBox)grid.Children[0]).Text;
            string value = ((TextBox)grid.Children[1]).Text;
            if (key == null || key == string.Empty || value == null || value == string.Empty) return; // key or value empty
            if (((CreateProjectViewModel)DataContext).Properties.ToList().FindAll((p) => p.Key == key).Count > 1) return; // key duplicate
            ToggleToRemove((Button)sender);
            ((CreateProjectViewModel)DataContext).Properties.Add(new ProjectProperty());
        }

        private void RemovePropertyBtn_Click(object sender, RoutedEventArgs e)
        {

            string key = ((TextBox)((Grid)((Button)sender).Parent).Children[0]).Text;
            ((CreateProjectViewModel)DataContext).RemoveProperty(key);
        }

        private void ToggleToRemove(Button button)
        {            
            ((PackIcon)button.Content).Kind = PackIconKind.Close;
            button.Click -= AddPropertyBtn_Click;
            button.Click += RemovePropertyBtn_Click;
        }
    }
}
