using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Models.Projects
{
    public class ProjectProperty
    {

        public ProjectProperty(string key=null, string value = null)
        {
            if (key != null)
                Key = key;
            if (value != null)
                Value = value;
        }            
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
