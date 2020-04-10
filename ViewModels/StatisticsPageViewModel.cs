using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ProjectTimeTrackerWPF.Models.Time;
using ProjectTimeTrackerWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.ViewModels
{
    class StatisticsPageViewModel : ViewModelBase
    {

        private List<WorkDay> _workDays;
        private SeriesCollection _series;

        public StatisticsPageViewModel()
        {
            Task.Run(() => LoadProjectTimes());
            SeriesCollection = new SeriesCollection();
        }

        public SeriesCollection SeriesCollection { 
            get => _series;
            set => Set(ref _series, value);
        }


        private async void LoadProjectTimes()
        {
            try
            {
                _workDays = await TimerDataService.LoadWorkDaysAsync();
                foreach (ProjectTime time in _workDays.First().ProjectTimes)
                {
                    SeriesCollection.Add(new PieSeries()
                    {
                        Title = time.Project.ProjectName,
                        Values = new ChartValues<ObservableValue> { new ObservableValue((time.End - time.Start).TotalMinutes) },
                        DataLabels = true
                    });
                }
            }
            catch (InvalidOperationException)
            {

            }
            
        }

    }
}
