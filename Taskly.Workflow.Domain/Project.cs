using System.Collections.Generic;
using System.Linq;

namespace Taskly.Workflow.Domain
{
    public class Project
    {
        public Project(string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
            : this(null, title, description, availableStatuses)
        {
        }

        private Project(string id, string title, string description, IEnumerable<WorkItemStatus> availableStatuses)
        {
            Id = id;
            Title = title;
            Description = description;
            AvailableStatuses = availableStatuses.ToList();
        }

        public string Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkItemStatus> AvailableStatuses { get; set; }
    }
}
