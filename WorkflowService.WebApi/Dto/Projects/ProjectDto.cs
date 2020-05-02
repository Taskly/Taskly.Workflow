using System.Collections.Generic;
using WorkflowService.WebApi.Dto.WorkItems;

namespace WorkflowService.WebApi.Dto.Projects
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
