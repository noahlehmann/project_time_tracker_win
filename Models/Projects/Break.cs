using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    /// <summary>
    /// Class to represent breaks during project work
    /// </summary>
    public sealed class Break : Project
    {
        /// <summary>
        /// Property to store planned or expected break duration per day
        /// </summary>
        public double HoursPerDay { get; set; }

    }
}
