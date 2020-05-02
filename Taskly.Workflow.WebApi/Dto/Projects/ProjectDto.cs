using System.Collections.Generic;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectDto
    {
        public ProjectDto(string title, string description, List<WorkItemStatusDto> availableStatuses)
        {
            Title = title;
            Description = description;
            AvailableStatuses = availableStatuses;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatusDto> AvailableStatuses { get; set; }
    }
}
