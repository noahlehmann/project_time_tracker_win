using ProjectTimeTrackerWPF.Models.Projects;
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

        public static async Task<WorkDay> LoadCurrentWorkDay()
        {
            await Task.Delay(0);
            WorkDay current = null;
            return current == null ? MockData.MockWorkDays.WorkDays[0] : current;
        }

        public static async Task<Dictionary<Project, int>> LoadProjectTimesGroupedByProjectsForWorkDay(WorkDay workDay)
        {
            await Task.Delay(0);
            Dictionary<Project, int> timePerProject = new Dictionary<Project, int>();
            foreach(ProjectTime time in workDay.ProjectTimes)
            {
                if (timePerProject.ContainsKey(time.Project))
                {
                    timePerProject[time.Project] += (int)(time.End - time.Start).TotalMinutes;
                }
                else
                {
                    timePerProject.Add(time.Project, (int)(time.End - time.Start).TotalMinutes);
                }
            }
            return timePerProject;
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
