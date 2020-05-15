using System;
using System.Collections.Generic;
using System.Linq;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectDto
    {
        public ProjectDto(Project model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            AvailableStatuses = model.AvailableStatuses.Select(x => new WorkItemStatusDto(x)).ToList();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatusDto> AvailableStatuses { get; set; }
    }
}
