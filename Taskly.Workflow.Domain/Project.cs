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

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<WorkItemStatus> AvailableStatuses => _availableStatuses;

        public void UpdateInfo(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void AddAvailableStatus(WorkItemStatus status)
        {
            if (_availableStatuses.Contains(status))
            {
                // TODO: throw
            }

            _availableStatuses.Add(status);
        }

        public void RemoveAvailableStatus(WorkItemStatus status)
        {
            if (!_availableStatuses.Contains(status))
            {
                // TODO: throw
            }

            if (_availableStatuses.Count == 1)
            {
                // TODO: throw
            }

            _availableStatuses.Remove(status);
        }

        private readonly List<WorkItemStatus> _availableStatuses;
    }
}
