using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Models.Time;
using ProjectTimeTrackerWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ProjectTimeTrackerWPF.ViewModels
{
    class StatisticsPageViewModel : ViewModelBase
    {
        #region private members

        private WorkDay _today;
        private Dictionary<Project, int> _projectTimesPerProjectToday;
        private SeriesCollection _series;
        private Dispatcher _dispatcher;
        private double _totalHours = 0;

        #endregion private members
        //#############################################################################
        #region constructor

        /// <summary>Basic constructor with dispatcher for UI updates</summary>
        /// <param name="dispatcher">UI dispatcher for updates</param>
        public StatisticsPageViewModel(Dispatcher dispatcher)
        {
            Task.Run(() => LoadProjectTimesForToday());
            _dispatcher = dispatcher;
        }

        #endregion constructor
        //#############################################################################
        #region observables

        public SeriesCollection SeriesCollection { 
            get => _series;
            set => Set(ref _series, value);
        }

        public double TotalHours
        {
            get => _totalHours;
            set => Set(ref _totalHours, value);
        }

        #endregion observables
        //#############################################################################
        #region public methods

        #endregion public methods
        //#############################################################################
        #region private methods

        /// <summary>Load data from DB and invoke display of data</summary>
        private async void LoadProjectTimesForToday()
        {
            _today = await TimerDataService.LoadCurrentWorkDay();
            _projectTimesPerProjectToday = await TimerDataService
                .LoadProjectTimesGroupedByProjectsForWorkDay(_today);
            _dispatcher.Invoke(() => HandleSeriesCollectionUpdate());
        }

        /// <summary>Reset the displayed chart with loaded data</summary>
        public void HandleSeriesCollectionUpdate()
        {
            SeriesCollection = new SeriesCollection();
            foreach (Project p in _projectTimesPerProjectToday.Keys)
            {
                double hours = Math.Round((double)_projectTimesPerProjectToday[p] / 60, 2);
                SeriesCollection.Add(
                    new PieSeries()
                    {
                        Values = new ChartValues<double> {hours},
                        Title = p.ProjectName
                    }
                );
                TotalHours += hours;
            }
        }

        #endregion private methods

    }
}
