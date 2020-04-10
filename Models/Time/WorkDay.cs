﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Time
{
    public class WorkDay
    {
        /// <summary>
        /// Database IDentifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Start of working day
        /// </summary>
        public DateTime Start { get; set; }
        
        /// <summary>
        /// End of working day
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Working intervals of projects
        /// </summary>
        public ICollection<ProjectTime> ProjectTimes { get; set; }


    }
}
