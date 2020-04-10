using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.ViewModels
{
    class TimerPageViewModel : ViewModelBase
    {

        private ObservableCollection<Project> _projects;

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => Set(ref _projects, value);
        }

        public TimerPageViewModel()
        {
            Task.Run(() => LoadProjects());
        }

        private async void LoadProjects()
        {
            List<Project> projects = await ProjectInfoDataService.LoadProjectsAsync();
            Projects = new ObservableCollection<Project>(projects);
        }
    }
}
