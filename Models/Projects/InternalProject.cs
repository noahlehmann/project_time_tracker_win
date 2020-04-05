using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    public class InternalProject : BusinessProject
    {

        /// <summary>
        /// Value to store info on internal organizational structure which hosts the project
        /// </summary>
        public string OrganizationalStructure { get; set; }

    }
}
