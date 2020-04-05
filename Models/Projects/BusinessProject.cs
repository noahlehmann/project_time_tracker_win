using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    /// <summary>
    /// Class to represent a project which creates business value
    /// </summary>
    public class BusinessProject : Project
    {
        /// <summary>
        /// Current Supervisor of project above the current user
        /// </summary>
        public string Supervisor { get; set; }

        /// <summary>
        /// Code which is used to book time
        /// </summary>
        public string ChargeCode { get; set; }
    }
}
