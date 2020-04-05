using Microsoft.EntityFrameworkCore;
using ProjectTimeTrackerWPF.Models.Projects;
using ProjectTimeTrackerWPF.Models.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models
{
    /// <summary>
    /// Database Context for the project timing related information
    /// </summary>
    class ProjectTimeDbContext : DbContext
    {
        /// <summary>
        /// Set of all project times
        /// </summary>
        public DbSet<ProjectTime> ProjectTimes { get; set; }

        /// <summary>
        /// Set of all workdays recorded
        /// </summary>
        public DbSet<WorkDay> WorkDays { get; set; }

        /// <summary>
        /// Set of all projects maintained
        /// </summary>
        public DbSet<Project> Projects { get; set; }
    }
}
