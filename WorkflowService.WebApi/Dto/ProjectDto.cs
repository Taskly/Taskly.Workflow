using System.Collections.Generic;
using System.Linq;
using WorkflowService.Domain;

namespace WorkflowService.WebApi.Dto
{
    public class ProjectDto
    {
        public ProjectDto(Project model)
        {
            Title = model.Title;
            Description = model.Description;
            AvailableStatuses = model.AvailableStatuses.Select(x => new WorkItemStatusDto(x)).ToList();
            WorkItems = model.WorkItems.Select(x => new WorkItemDto(x)).ToList();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatusDto> AvailableStatuses { get; set; }

        public List<WorkItemDto> WorkItems { get; set; }
    }
}
