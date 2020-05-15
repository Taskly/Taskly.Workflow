using System;
using System.Collections.Generic;
using System.Linq;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectWorkItemsDto
    {
        public ProjectWorkItemsDto(Project projectModel, List<WorkItem> workItemsModel)
        {
            Id = projectModel.Id;
            Title = projectModel.Title;
            Description = projectModel.Description;
            AvailableStatuses = projectModel.AvailableStatuses.Select(x => new WorkItemStatusDto(x)).ToList();
            WorkItems = workItemsModel.Select(x => new WorkItemDto(x)).ToList();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatusDto> AvailableStatuses { get; set; }

        public List<WorkItemDto> WorkItems { get; set; }
    }
}
