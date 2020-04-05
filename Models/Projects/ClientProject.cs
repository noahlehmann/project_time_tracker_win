using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    public class ClientProject : BusinessProject
    {
        /// <summary>
        /// Name of Client to deliver project to
        /// </summary>
        public string Client { get; set; }

    }
}
