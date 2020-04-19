using ProjectTimeTrackerWPF.Models;
using ProjectTimeTrackerWPF.Models.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Service
{
    class ProjectInfoDataService
    {

        public static async Task<List<Project>> LoadProjectsAsync()
        {
            await Task.Delay(0);

            List<Project> projects = new List<Project>();

            using (var db = new ProjectTimeDbContext())
            {
                projects.AddRange(db.Projects.ToList());
            }
            return projects.Count == 0 ? MockData.MockProjects.Projects : projects;
        }

        public static void SaveProject(Project project)
        {
            using (var db = new ProjectTimeDbContext())
            {
                db.Projects.Add(project);
                try
                {
                    db.SaveChanges();
                }catch (DbEntityValidationException)
                {
                    Console.WriteLine("Couldn't save entity.");
                }
            }
        }
    }
}
