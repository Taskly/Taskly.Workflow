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

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses;

        public IReadOnlyCollection<WorkItem> WorkItems => _workItems;

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddWorkItem(WorkItem workItem)
        {
            _workItems.Add(workItem);
        }

        private readonly List<WorkItemStatus> _availableStatuses;
        private readonly List<WorkItem> _workItems;
    }
}
