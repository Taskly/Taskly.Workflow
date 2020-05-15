﻿using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemStatusDto
    {
        public WorkItemStatusDto()
        {
        }

        public WorkItemStatusDto(WorkItemStatus model)
        {
            Title = model.Title;
        }

        public string Title { get; set; }

        public WorkItemStatus ToModel()
        {
            return new WorkItemStatus(Title);
        }
    }
}
