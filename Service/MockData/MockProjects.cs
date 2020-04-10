﻿using ProjectTimeTrackerWPF.Models.Projects;
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
                    new PersonalOrganization()
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
                    new ClientProject()
                    {
                        Description = "Project Financial analysis for client XYZ",
                        ProjectName = "Financial XYZ",
                        Client = "XYZ",
                        Supervisor = "Mr. Supervisor",
                        ChargeCode = "12345678",
                        Id = 3
                    },
                    new InternalProject()
                    {
                        Description = "Internal Business Creation",
                        ProjectName = "Internal Project",
                        OrganizationalStructure = "Financing",
                        ChargeCode = "87654321",
                        Supervisor = "Mr. Internal-Supervisor",
                        Id = 4
                    }
                };
            }
        }
    }
}
