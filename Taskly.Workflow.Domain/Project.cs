using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Taskly.Workflow.Domain
{
    public class Project
    {
        public Project(string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
        {
            Title = title;
            Description = description;
            _availableStatuses = new List<WorkItemStatus>(availableStatuses);
        }

        public string Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public ReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses.AsReadOnly();

        private readonly List<WorkItemStatus> _availableStatuses;
    }
}
