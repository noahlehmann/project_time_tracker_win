using ProjectTimeTrackerWPF.Models.Projects;
using System;
using System.Collections.Generic;
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


            return projects.Count == 0 ? MockData.MockProjects.Projects : projects;
        }
    }
}
