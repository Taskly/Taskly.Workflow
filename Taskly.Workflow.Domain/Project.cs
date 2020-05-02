using System.Collections.Generic;

namespace Taskly.Workflow.Domain
{
    public class Project
    {
        public Project(string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
            : this(string.Empty, title, description, availableStatuses)
        {
        }

        private Project(string id, string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
        {
            Id = id;
            Title = title;
            Description = description;
            _availableStatuses = new List<WorkItemStatus>(availableStatuses);
        }

        public string Id { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses;

        private readonly List<WorkItemStatus> _availableStatuses;
    }
}
