using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    /// <summary>
    /// Abstract class for storing Project based information
    /// </summary>
    public abstract class Project
    {
        /// <summary>
        /// Database Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of project
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Quick description of project purpose
        /// </summary>
        public string Description { get; set; }

    }
}
