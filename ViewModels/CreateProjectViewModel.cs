using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectTimeTrackerWPF.ViewModels
{
    class CreateProjectViewModel : ViewModelBase
    {
        #region private members

        private ObservableCollection<ProjectProperty> _properties;
        private string _projectName;
        private string _projectDescription;

        #endregion private members
        //#############################################################################
        #region Constructor
        
        /// <summary>Basic Constructor</summary>
        public CreateProjectViewModel()
        {
            Properties = new ObservableCollection<ProjectProperty>()
            {
                new ProjectProperty("", "")
            };
        }

        #endregion Constructor
        //#############################################################################
        #region Observables

        public ObservableCollection<ProjectProperty> Properties
        {
            get => _properties;
            set => Set(ref _properties, value);
        }

        public string ProjectName
        {
            get => _projectName;
            set => Set(ref _projectName, value);
        }

        public string ProjectDescription
        {
            get => _projectDescription;
            set => Set(ref _projectDescription, value);
        }

        #endregion Observables
        //#############################################################################
        #region public methods

        public void RemoveProperty(string key)
        {
            ProjectProperty propertyToRemove = Properties.First((p) => p.Key == key);
            if (propertyToRemove != null)
            {
                Properties.Remove(propertyToRemove);
            }
        }

        public void SaveProject()
        {
            ProjectInfoDataService.SaveProject(new Project()
            {
                ProjectName = _projectName,
                Description = _projectDescription,
                Properties = FilterProjectProperties(_properties)
            });
        }

        #endregion public methods
        //#############################################################################
        #region private methods

        private List<ProjectProperty> FilterProjectProperties(IEnumerable<ProjectProperty> properties)
        {
            List<ProjectProperty> finals = properties.ToList();
            foreach (ProjectProperty p in properties.ToList().FindAll((p) => p.Key == null || p.Key == string.Empty))
            {
                finals.Remove(p);
            }
            return finals;
        }

        #endregion private methods

    }
}
