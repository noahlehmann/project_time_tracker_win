using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTimeTrackerWPF.Models.Projects;

namespace ProjectTimeTrackerWPF.Models.Time
{
    /// <summary>
    /// Base Class for Time spent on Projects
    /// </summary>
    public class ProjectTime
    {
        /// <summary>
        /// Database identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Start of project work time
        /// </summary>
        public DateTime Start { get; set; }
        
        /// <summary>
        /// End of project work time
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Mapping to infomation of project
        /// </summary>
        public Project Project { get; set; }


    }
}
