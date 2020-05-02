using System.Collections.Generic;
using WorkflowService.WebApi.Dto.WorkItems;

namespace WorkflowService.WebApi.Dto.Projects
{
    public class ProjectUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatusDto> AvailableStatuses { get; set; }
    }
}
