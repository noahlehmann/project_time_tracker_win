using ProjectTimeTrackerWPF.Models.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Service
{
    public class TimerDataService
    {

        public static async Task<List<WorkDay>> LoadWorkDaysAsync()
        {
            await Task.Delay(0);

            List<WorkDay> workDays = new List<WorkDay>();

            /*using (var db = new ProjectTimeDbContext())
            {
                workDays = db.WorkDays.ToList();
            }*/
            
            return workDays.Count == 0 ? MockData.MockWorkDays.WorkDays : workDays;
        }

        public static void SaveProjectTime(ProjectTime currentProjectTime)
        {
            //Do magic in DB, save to current Workday
            double diff = (currentProjectTime.End - currentProjectTime.Start).TotalSeconds;
            string value = $"Stopped {currentProjectTime.Project.ProjectName}; {diff}s elapsed";
            Console.WriteLine(value);
        }
    }
}
