using System;

namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public WorkItemStatusDto Status { get; set; }
    }
}
