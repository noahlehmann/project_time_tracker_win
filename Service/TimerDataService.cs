using ProjectTimeTrackerWPF.Models;
using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Models.Time;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
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

            using (var db = new ProjectTimeDbContext())
            {
                if (TodayExists(db.WorkDays))
                {
                    current = GetToday(db);
                }
                else
                {
                    current = WorkDay.StartingNow;
                    db.WorkDays.Add(current);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Couldn't save Workday");
                    }
                }
            }
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
            using (var db = new ProjectTimeDbContext())
            {
                WorkDay today;
                if (TodayExists(db.WorkDays))
                {
                    today = GetToday(db);
                    today.ProjectTimes.Add(currentProjectTime);
                }
                else
                {
                    today = WorkDay.StartingNow;
                    today.ProjectTimes.Add(currentProjectTime);
                    db.WorkDays.Add(today);
                }
                today.End = currentProjectTime.End;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't save ProjectTime");
                }
            }
            double diff = (currentProjectTime.End - currentProjectTime.Start).TotalSeconds;
            string value = $"Stopped {currentProjectTime.Project.ProjectName}; {diff}s elapsed";
            Console.WriteLine(value);
        }

        public static void EndWorkDay()
        {
            using (var db = new ProjectTimeDbContext())
            {
                if (TodayExists(db.WorkDays))
                {
                    DateTime start = DateTime.Today;
                    DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
                    WorkDay today = GetToday(db);                       
                    if (today.ProjectTimes.Count() > 0)
                    {
                        today.End = today.ProjectTimes
                            .Where(t => t.End == today.ProjectTimes.Max(pt => pt.End))
                            .First()
                            .End;
                    }
                    else
                    {
                        db.WorkDays.Remove(today);
                    }
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    Console.WriteLine("Couldn't end Workday");
                }
            }
        }

        #region private methods

        /// <summary>Checks whether today has a workday already</summary>
        /// <param name="q">Queriable of Workdays</param>
        /// <returns></returns>
        private static bool TodayExists(IQueryable<WorkDay> q)
        {           
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
            return (q.Where(day => start < day.Start && day.Start < end).Count() > 0);            
        }

        /// <summary>Returns todays workday, dows not check if it exists, check before!</summary>
        /// <param name="q">Queriable of workdays</param>
        /// <returns></returns>
        private static WorkDay GetToday(ProjectTimeDbContext db)
        {
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
            return (from wd in db.WorkDays.Include("ProjectTimes").Include("ProjectTimes.Project")
                    where start < wd.Start && wd.Start < end
                    select wd).First();
        }

        #endregion private methods

    }
}
