using ProjectTimeTrackerWPF.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTrackerWPF.Service.MockData
{
    class MockProjects
    {
        public static List<Project> Projects
        {
            get
            {
                return new List<Project>()
                {
                    new Project()
                    {
                        Description = "Time spent on organizational tasks",
                        ProjectName = "Organizational",
                        Id = 1
                    },
                    new Break()
                    {
                        Description = "Break Time spent between projects",
                        ProjectName = "Break",
                        Id = 2
                    },
                    new Project()
                    {
                        Description = "Project Financial analysis for client XYZ",
                        ProjectName = "Financial XYZ",
                        Properties = new List<ProjectProperty>()
                        {
                            new ProjectProperty(){Key = "Client", Value = "XYZ"},
                            new ProjectProperty(){Key = "Supervisor", Value = "Mr. Supervisor"},
                            new ProjectProperty(){Key = "ChargeCode", Value = "12345678"},
                        },
                        Id = 3
                    },
                    new Project()
                    {
                        Description = "Internal Business Creation",
                        ProjectName = "Internal Project",
                        Properties = new List<ProjectProperty>()
                        {
                            new ProjectProperty(){Key = "OrganizationalStructure", Value = "Financing"},
                            new ProjectProperty(){Key = "Supervisor", Value = "Mr. Internal-Supervisor"},
                            new ProjectProperty(){Key = "ChargeCode", Value = "87654321"},
                        },
                        Id = 4
                    }
                };
            }
        }
    }
}
