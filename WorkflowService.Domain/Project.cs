using System.Collections.Generic;

namespace WorkflowService.Domain
{
    public class Project
    {
        public Project(string title)
            : this(title, string.Empty, new List<WorkItemStatus>(), new List<WorkItem>())
        {
        }

        public Project(string title, string description, IEnumerable<WorkItemStatus> availableStatuses,
            IEnumerable<WorkItem> workItems)
        {
            Title = title;
            Description = description;
            _availableStatuses = new List<WorkItemStatus>(availableStatuses);
            _workItems = new List<WorkItem>(workItems);
        }

        public string Title { get; }

        public string Description { get; }

        public IReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses;

        public IReadOnlyCollection<WorkItem> WorkItems => _workItems;

        private readonly List<WorkItemStatus> _availableStatuses;
        private readonly List<WorkItem> _workItems;
    }
}
