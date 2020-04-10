using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Models.Time;
using ProjectTimeTrackerWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ProjectTimeTrackerWPF.ViewModels
{
    class TimerPageViewModel : ViewModelBase
    {

        #region private members

        private readonly int MINUTE = 60, HOUR = 3600;
        
        private ObservableCollection<Project> _projects;
        private string _displayTime = "0s";
        private int _timerSeconds;
        private bool _isTimerRunning;
        private DispatcherTimer _dispatcherTimer;

        private bool _isProjectSelectionAllowed = true;
        private bool _isStartTimerAllowed = false;
        private bool _isStopTimerAllowed = false;

        private Project _selectedProject;

        private ProjectTime currentProjectTime;

        #endregion private members
        //#############################################################################
        #region constructor

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public TimerPageViewModel()
        {
            Task.Run(() => LoadProjects());
        }

        #endregion constructor
        //#############################################################################
        #region observables

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => Set(ref _projects, value);
        }

        public DispatcherTimer Timer { get; set; }

        public string DisplayTime 
        { 
            get => _displayTime; 
            set => Set(ref _displayTime, value); 
        }

        public bool IsTimerRunning
        {
            get => _isTimerRunning;
            set => Set(ref _isTimerRunning, value);
        }

        public bool IsProjectSelectionAllowed
        {
            get => _isProjectSelectionAllowed;
            set => Set(ref _isProjectSelectionAllowed, value);
        }

        public bool IsStartTimerAllowed
        {
            get => _isStartTimerAllowed;
            set => Set(ref _isStartTimerAllowed, value);
        }

        public bool IsStopTimerAllowed
        {
            get => _isStopTimerAllowed;
            set => Set(ref _isStopTimerAllowed, value);
        }

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                Set(ref _selectedProject, value);
                HandleTimerOnProjectSelection(value);
            }
        }

        #endregion observables
        //#############################################################################
        #region public methods

        /// <summary>Starts Timer Logic</summary>
        public void StartTimer()
        {
            if (!IsStartTimerAllowed || _dispatcherTimer.IsEnabled) return;
            if(_dispatcherTimer == null)
            {
                ResetTimer();
            }
            if(_timerSeconds == 0)
            {
                StartNewProjectTime();
            }
            _dispatcherTimer.Start();
            IsTimerRunning = true;
            IsProjectSelectionAllowed = false;
            IsStartTimerAllowed = false;
            IsStopTimerAllowed = true;
        }


        /// <summary>
        /// Pauses Timer Logic, second call without starting 
        /// timer in between will reset the timer
        /// </summary>
        public void StopTimer()
        {
            if (!IsStopTimerAllowed) return;
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
            }
            else
            {
                IsStopTimerAllowed = false;
                _dispatcherTimer.Stop();
                ResetTimer();
                StopCurrentProjectTime();

            }
            IsTimerRunning = false;
            IsProjectSelectionAllowed = true;
            IsStartTimerAllowed = true;
        }

        /// <summary>Resets Timer to defaults</summary>
        public void ResetTimer()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _timerSeconds = 0;
            DisplayTime = _timerSeconds + "s";
            IsTimerRunning = false;
        }


        #endregion public methods
        //#############################################################################
        #region private methods

        /// <summary>
        /// Method to load projects from database into the members
        /// </summary>
        private async void LoadProjects()
        {
            List<Project> projects = await ProjectInfoDataService.LoadProjectsAsync();
            Projects = new ObservableCollection<Project>(projects);
        }

        /// <summary>Logic to be executed on each timer tick</summary>
        /// <param name="sender">event sender, dispatcherTimer preffered</param>
        /// <param name="e">event causing this call</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            ++_timerSeconds;
            DisplayTime = _timerSeconds + "s";
        }

        /// <summary>
        /// Method to set button enabled property and timer settings on change of project
        /// </summary>
        /// <param name="selected">selected project</param>
        private void HandleTimerOnProjectSelection(Project selected)
        {
            if (selected != null)
            {
                IsStartTimerAllowed = true;
                IsStopTimerAllowed = true;
                ResetTimer();
                StopCurrentProjectTime();
            }
            else
            {
                IsStartTimerAllowed = false;
                IsStopTimerAllowed = false;
            }
        }

        /// <summary>
        /// Starts new ProjectTime with selected project
        /// </summary>
        private void StartNewProjectTime()
        {
            currentProjectTime = new ProjectTime()
            {
                Project = SelectedProject,
                Start = DateTime.Now
            };
            Console.WriteLine("Started " + currentProjectTime.Project.ProjectName);
        }

        /// <summary>
        /// Stop the current project time and persists it
        /// </summary>
        private void StopCurrentProjectTime()
        {
            if (currentProjectTime == null) return;
            currentProjectTime.End = DateTime.Now;            
            TimerDataService.SaveProjectTime(currentProjectTime);
        }

        #endregion private methods

    }
}
