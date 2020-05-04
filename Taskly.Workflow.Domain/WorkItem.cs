using System;

namespace Taskly.Workflow.Domain
{
    public class WorkItem
    {
        public WorkItem(Guid projectId, string title, string description, WorkItemStatus status)
            : this(Guid.Empty, projectId, title, description, status)
        {
        }

        private WorkItem(Guid id, Guid projectId, string title, string description, WorkItemStatus status)
        {
            Id = id;
            ProjectId = projectId;
            Title = title;
            Description = description;
            Status = status;
        }

        public Guid Id { get; private set; }

        public Guid ProjectId { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public WorkItemStatus Status { get; set; }
    }
}
