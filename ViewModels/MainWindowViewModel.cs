using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region PrivateMembers

        private ObservableCollection<Project> _projects;

        #endregion PrivateMembers
        #region Properties

        public string User { get; }

        #endregion Properties

        public MainWindowViewModel()
        {
            User = Environment.UserName;
        }

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => Set(ref _projects, value);
        }

    }
}
