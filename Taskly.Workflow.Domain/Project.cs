using System;
using System.Collections.Generic;

namespace Taskly.Workflow.Domain
{
    public class Project
    {
        public Project(string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
            : this(Guid.Empty, title, description, availableStatuses)
        {
        }

        private Project(Guid id, string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
        {
            Id = id;
            Title = title;
            Description = description;
            _availableStatuses = new List<WorkItemStatus>(availableStatuses);
        }

        public Guid Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses;

        private readonly List<WorkItemStatus> _availableStatuses;
    }
}
