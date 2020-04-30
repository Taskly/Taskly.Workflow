﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkflowService.Domain
{
    public interface IProjectsRepository
    {
        Task<List<Project>> GetProjectsInfo();

        Task<Project> GetProject(string id);

        Task SaveProject(Project project);
    }
}