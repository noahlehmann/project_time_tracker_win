using ProjectTimeTrackerWPF.Models;
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
            
            return workDays.Count == 0 ? getDummyWorkDays() : workDays;
        }

        private static List<WorkDay> getDummyWorkDays()
        {
            Project a = new PersonalOrganization()
            {
                Description = "Time spent on organizational tasks",
                ProjectName = "Organizational",
                Id = 1
            };
            Project b = new Break()
            {
                Description = "Break Time spent between projects",
                ProjectName = "Break",
                Id = 2
            };
            Project c = new ClientProject()
            {
                Description = "Project Financial analysis for client XYZ",
                ProjectName = "Financial XYZ",
                Client = "XYZ",
                Supervisor = "Mr. Supervisor",
                ChargeCode = "12345678",
                Id = 3
            };
            return new List<WorkDay>() {
                new WorkDay()
                {
                    Start = new DateTime(2020, 4, 1, 7, 0, 0),
                    End = new DateTime(2020, 4, 1, 16, 30, 0),
                    ProjectTimes = new List<ProjectTime>()
                    {
                        new ProjectTime()
                        {
                            Start = new DateTime(2020,4,1,7,0,0),
                            End = new DateTime(2020,4,1,7,46,0),
                            Project = a
                        },
                        new ProjectTime()
                        {
                            Start = new DateTime(2020,4,1,7,46,0),
                            End = new DateTime(2020,4,1,11,22,0),
                            Project = c
                        },
                        new ProjectTime()
                        {
                            Start = new DateTime(2020,4,1,11,22,0),
                            End = new DateTime(2020,4,1,12,11,0),
                            Project = b
                        },
                        new ProjectTime()
                        {
                            Start = new DateTime(2020,4,1,12,11,0),
                            End = new DateTime(2020,4,1,16,2,0),
                            Project = c
                        },
                        new ProjectTime()
                        {
                            Start = new DateTime(2020,4,1,16,2,0),
                            End = new DateTime(2020,4,1,16,30,0),
                            Project = a
                        }
                    }
                }
            };
            
        }
    }
}
